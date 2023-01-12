using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private GameManager gameMng;
    [SerializeField]
    private GameObject scanObj;
    [SerializeField]
    private Text uiText;

    // inputs
    public Controls controls;
    Vector2 inputs, inputNormalized;
    float rotation;
    bool run = true, jump;

    // velocity
    Vector3 velocity;
    float gravity = -18.0f, velocityY, terminalVelocity = -25.0f;
    float fallMult;

    // running
    float currSpeed;
    public float baseSpeed = 1.0f, runSpeed = 4.0f, rotateSpeed = 2.0f;

    //Ground
    Vector3 forwardDirection, collisionPoint;
    float slopeAngle, forwardAngle, forwardMult;
    Ray groundRay;
    RaycastHit groundHit;

    // jumping
    bool isJumped;
    float jumpSpeed, jumpHeight = 3.0f;
    Vector3 jumpDirection;

    // reference
    CharacterController controller;
    public Transform groundDirection, fallDirection;
    [HideInInspector]
    public CamCtrl mainCam;
    //animation
    public Animator anim;
    private readonly int isRunning = Animator.StringToHash("IsRunning");
    private readonly int isMovedBack = Animator.StringToHash("IsMovedBack");
    private readonly int isGoingLeft = Animator.StringToHash("IsGoingLeft");
    private readonly int isGoingRight = Animator.StringToHash("IsGoingRight");
    private readonly int isTurnLeft = Animator.StringToHash("IsTurnLeft");
    private readonly int isTurnRight = Animator.StringToHash("IsTurnRight");
    private readonly int isJumping = Animator.StringToHash("IsJumping1");
    private readonly int isSwang = Animator.StringToHash("IsSwang");
    private readonly int isWalking = Animator.StringToHash("IsWalking1");
    private readonly int isArmed = Animator.StringToHash("IsArmed");

    void Start()
    {
        // load character controller when starts
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        GetInputs();

        Locomotion();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward - new Vector3(0f, 0.1f, 0f) * 5f, new Color(0, 1, 0));
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(transform.forward.x, 0.1f, transform.forward.z), out hit, 2f, LayerMask.GetMask("Object")))
        {
            scanObj = hit.transform.gameObject;
            if (!gameMng.GetisAction)
                uiText.text = "대화하기" + " <color=red>[G]</color>";
        }
        else
        {
            scanObj = null;
            uiText.text = "";
        }
    }

    void Locomotion()
    {
        GroundDirection();

        //running and walking
        if (controller.isGrounded && slopeAngle <= controller.slopeLimit)
        {
            inputNormalized = inputs;
            currSpeed = baseSpeed;

            if (run)
            {
                currSpeed *= runSpeed;

                if (inputNormalized.y < 0)
                {
                    currSpeed = currSpeed / 2.0f;
                }
            }
            else if (!controller.isGrounded || slopeAngle > controller.slopeLimit)
            {
                inputNormalized = Vector2.Lerp(inputNormalized, Vector2.zero, 0.025f);
                currSpeed = Mathf.Lerp(currSpeed, 0, 0.025f);
            }
        }


        //rotating                      
        Vector3 characterRotation = transform.eulerAngles + new Vector3(0, rotation * rotateSpeed, 0);

        characterRotation = gameMng.GetisAction ? transform.eulerAngles : characterRotation;

        transform.eulerAngles = characterRotation;


        // //press space to jump
        if (jump && controller.isGrounded && slopeAngle <= controller.slopeLimit)
        {

            Jump();


        }
        // apply gravity if not grounded
        if (!controller.isGrounded && velocityY > terminalVelocity)
        {
            velocityY += gravity * Time.deltaTime;
        }
        else if (controller.isGrounded && slopeAngle > controller.slopeLimit)
        {
            velocityY = Mathf.Lerp(velocityY, terminalVelocity, 0.025f);
        }


        //applying inputs
        if (!isJumped)
        {
            //anim.SetBool(isJumping, false);
            velocity = (groundDirection.forward * inputNormalized.magnitude) * (currSpeed * forwardMult) + fallDirection.up * (velocityY * fallMult);
        }
        else
        {
            velocity = jumpDirection * jumpSpeed + Vector3.up * velocityY;
        }

        velocity = gameMng.GetisAction ? Vector3.zero : velocity;

        if (Input.GetKeyDown(KeyCode.G) && scanObj != null)
        {
            gameMng.Action(scanObj);
        }

        //moving controller
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            // stop jumping if grounded
            if (isJumped)
            {
                isJumped = false;

            }
            //stop gravity if grounded
            velocityY = 0;
        }
        void GroundDirection()
        {
            // setting forwarddirection
            // setting forwarddirection to controller position
            forwardDirection = transform.position;
            // setting forwardDirection based on control input
            if (inputNormalized.magnitude > 0)
            {
                forwardDirection += transform.forward * inputNormalized.y + transform.right * inputNormalized.x;
            }
            else
            {
                forwardDirection += transform.forward;
            }
            // setting groundDirection to look  in the forwardDirection normal
            groundDirection.LookAt(forwardDirection);
            fallDirection.rotation = transform.rotation;
            // setting ground ray
            groundRay.origin = collisionPoint + Vector3.up * 0.05f;
            groundRay.direction = Vector3.down;

            forwardMult = 1.0f;
            fallMult = 1.0f;

            if (Physics.Raycast(groundRay, out groundHit, 0.55f))
            {
                // getting angles
                slopeAngle = Vector3.Angle(transform.up, groundHit.normal);
                forwardAngle = Vector3.Angle(groundDirection.forward, groundHit.normal) - 90.0f;

                if (forwardAngle < 0 && slopeAngle <= controller.slopeLimit)
                {
                    forwardMult = 1 / Mathf.Cos(forwardAngle * Mathf.Deg2Rad);
                    //setting groundDirection based on forwardAngle
                    groundDirection.eulerAngles += new Vector3(-forwardAngle, 0, 0);
                }
                else if (slopeAngle > controller.slopeLimit)
                {
                    float groundDistance = Vector3.Distance(groundRay.origin, groundHit.point);
                    if (groundDistance <= 0.1f)
                    {
                        fallMult = 1 / Mathf.Cos((90 - slopeAngle) * Mathf.Deg2Rad);
                        Vector3 groundCross = Vector3.Cross(groundHit.normal, Vector3.up);
                        fallDirection.rotation = Quaternion.FromToRotation(transform.up, Vector3.Cross(groundCross, groundHit.normal));
                    }
                }
            }

        }
        void Jump()
        {
            //set jumping to true
            if (!isJumped)
            {
                isJumped = true;
                //set jump direction and speed
                jumpDirection = (transform.forward * inputs.y + transform.right * inputs.x).normalized;
                jumpSpeed = currSpeed;
                //set velocityY
                velocityY = Mathf.Sqrt(-gravity * jumpHeight);

            }
            //anim.SetBool(isJumping, true);


        }
    }

    void GetInputs()
    {   //Forwards,Backwards controls

        if (Input.GetKeyDown(KeyCode.M))
        {
            //anim.SetBool(isArmed, true);
        }

        //forwards
        if (Input.GetKey(controls.forwards))
        {
            inputs.y = 1.0f;
            //anim.SetBool(isRunning, true);
        }
        if (!Input.GetKey(controls.forwards))
        {
            //anim.SetBool(isRunning, false);
        }

        //backwards
        if (Input.GetKey(controls.backwards))
        {
            if (Input.GetKey(controls.forwards))
            {
                inputs.y = 0;

            }
            else
            {
                inputs.y = -1.0f;
                //anim.SetBool(isMovedBack, true);

            }
        }
        if (!Input.GetKey(controls.backwards))
        {
            //anim.SetBool(isMovedBack, false);
        }

        //FW nothing
        if (!Input.GetKey(controls.forwards) && !Input.GetKey(controls.backwards))
        {
            inputs.y = 0;

        }

        //StrafeLeft,Right
        //StrafeRight
        if (Input.GetKey(controls.strafeRight))
        {
            inputs.x = 1.0f;
            //anim.SetBool(isGoingRight, true);

        }
        if (!Input.GetKey(controls.strafeRight))
        {
            //anim.SetBool(isGoingRight, false);
        }

        //StrafeLeft
        if (Input.GetKey(controls.strafeLeft))
        {
            if (Input.GetKey(controls.strafeRight))
            {
                inputs.x = 0;
            }
            else
            {
                inputs.x = -1.0f;
                //anim.SetBool(isGoingLeft, true);
            }
        }
        if (!Input.GetKey(controls.strafeLeft))
        {
            //anim.SetBool(isGoingLeft, false);
        }

        //StrafeLR nothing
        if (!Input.GetKey(controls.strafeLeft) && !Input.GetKey(controls.strafeRight))
        {
            inputs.x = 0;
        }

        //RotateLeft,Right
        //RotateRight
        if (Input.GetKey(controls.rotateRight))
        {
            rotation = 1.0f;
            //anim.SetBool(isTurnRight, true);
        }
        if (!Input.GetKey(controls.rotateRight))
        {
            //anim.SetBool(isTurnRight, false);
        }
        //RotateLeft
        if (Input.GetKey(controls.rotateLeft))
        {
            if (Input.GetKey(controls.rotateRight))
            {
                rotation = 0;
            }
            else
            {
                rotation = -1.0f;
                //anim.SetBool(isTurnLeft, true);
            }
        }
        if (!Input.GetKey(controls.rotateLeft))
        {
            //anim.SetBool(isTurnLeft, false);
        }

        //RotateLR nothing
        if (!Input.GetKey(controls.rotateLeft) && !Input.GetKey(controls.rotateRight))
        {
            rotation = 0;
        }

        //Interaction
        if (Input.GetKeyDown(KeyCode.R))
        {
            //anim.SetBool(isSwang, true);

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            //anim.SetBool(isSwang, false);
        }

        //toggle run

        if (Input.GetKey(controls.walkRun))
        {
            run = !run;
            //anim.SetBool(isWalking, true);
        }
        //anim.SetBool(isWalking, false);
        // if (!Input.GetKey(controls.walkRun))
        // {
        //     !run = run;
        //     
        // }


        // jump

        jump = Input.GetKey(controls.jump);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    anim.Play("Jump");
        //}


    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        collisionPoint = hit.point;
    }
    //Input for interaction
    //anim.SetBool(isSwang, true);

    //if(Input.GetKeyUp(KeyCode.F))
    //{
    //anim.SetBool(isSwang, false);
    //}


}





