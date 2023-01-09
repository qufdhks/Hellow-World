using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    // Input variables
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1, middleMouse = KeyCode.Mouse2;

    // Camera variables
    public float cameraHeight = 1.0f, cameraMaxDistance = 15.0f;
    float cameraMaxTilt = 90.0f;
    [Range(0, 4)]
    public float cameraSpeed = 2.0f;
    float currentPan, currentTilt = 10.0f, currentDistance = 5.0f;

    // Camera States
    public CameraState cameraState = CameraState.CameraNone;

    // References
    PlayerControls player;
    public Transform tilt;
    Camera mainCam;

    void Start()
    {
        player = FindObjectOfType<PlayerControls>();
        player.mainCam = this;
        mainCam = Camera.main;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCam.transform.position += tilt.forward * -currentDistance;

    }


    void Update()
    {//!Input.GetKey(leftMouse) &&
        if (!Input.GetKey(leftMouse) && !Input.GetKey(rightMouse) && !Input.GetKey(middleMouse))
        {
            //cameraState = CameraState.CameraNone;
        }
        else if (Input.GetKey(leftMouse))
        {
            if (!Inventory.invectoryActivated)
                cameraState = CameraState.CameraRotate;
        }
        else if (Input.GetKey(rightMouse))
        {
            cameraState = CameraState.CameraNone;
        }
        //else
        //{
        //
        //}
        CameraInputs();
    }
    void LateUpdate()
    {
        CameraTransform();
    }
    void CameraInputs()
    {
        if (cameraState != CameraState.CameraNone && Input.GetKey(leftMouse))
        {
            if (cameraState == CameraState.CameraRotate)
            {
                currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
            }
            currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed;
            currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt);
        }
        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * 2.0f;
        currentDistance = Mathf.Clamp(currentDistance, 0, cameraMaxDistance);

    }
    void CameraTransform()
    {
        switch (cameraState)
        {
            case CameraState.CameraNone:
                {
                    currentPan = player.transform.eulerAngles.y;
                    currentTilt = 10.0f;
                    break;
                }
        }
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCam.transform.position = transform.position + tilt.forward * -currentDistance;
    }
    public enum CameraState { CameraNone, CameraRotate, CameraSteer, CameraRun }
}
