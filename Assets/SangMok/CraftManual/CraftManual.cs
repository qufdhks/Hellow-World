using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Craft
{
    public string craftName;//이름
    public GameObject go_Prefab;//설치될 프리팹
    public GameObject go_PreviewPrefab;//미리보기 프리팹
}

public class CraftManual : MonoBehaviour
{
    //상태변수
    public bool clearQuest = false;
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_BaseUI;//기본 베이스 UI

    [SerializeField]
    private Craft[] craft_house;//집관련 탭

    private GameObject go_Preview;//프리팹 미리보기 담을 변수
    private GameObject go_Prefab;// 실제 생성될 프리팹을 담을 변수


    [SerializeField]
    private Transform tf_Player;//플레이어 위치

    //private RaycastHit hitinfo;
    
    [SerializeField]
    private LayerMask layerMask;

    //[SerializeField]
    //private float range;


    public void SlotClick(int _slotNumber)
    {
        Debug.Log("클릭됨");
        go_Preview = Instantiate(craft_house[_slotNumber].go_PreviewPrefab, tf_Player.position + (tf_Player.forward * 1f) + new Vector3(0f, -0.5f,0f), Quaternion.identity);
        go_Prefab = craft_house[_slotNumber].go_Prefab;
        isPreviewActivated = true;
        go_BaseUI.SetActive(false);
    }


    void Start()
    {
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPreviewActivated && clearQuest)
        {
            Window();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Build();
        }


        //if (isPreviewActivated)
        //    PreviewPositionUpdate();


        if (Input.GetKeyDown(KeyCode.C))
        {
            Cancel();
        }
    }

    private void Build()
    {
        if(isPreviewActivated && go_Preview.GetComponent<PreviewObject>().IsBuildable())
        {
            Instantiate(go_Prefab, tf_Player.position + (tf_Player.forward * 10f) + new Vector3(0f, -1.2f, 0f), Quaternion.identity);
            Destroy(go_Preview);
            isActivated = false;
            isPreviewActivated=false;
            go_Preview = null;
            go_Prefab = null;
        }
    }

    //private void PreviewPositionUpdate()
    //{
    //    if(Physics.Raycast(tf_Player.position, tf_Player.forward, out hitinfo, range, layerMask))
    //    {
    //        if(hitinfo.transform != null)
    //        {
    //            Vector3 _location = hitinfo.point;
    //            go_Preview.transform.position = _location;
    //        }
    //    }
    //}


    private void Cancel() 
    {
        if(isPreviewActivated)
            Destroy(go_Preview);

        isActivated = false;
        isPreviewActivated = false;
        go_Preview = null;
        go_Prefab = null;

        go_BaseUI.SetActive(false);

    }

    private void Window()
    {
        if (!isActivated)
            OpenWindow();
        else
            CloseWindow();
    }

    private void OpenWindow()
    {
        isActivated = true;
        go_BaseUI.SetActive(true);
    }

    private void CloseWindow()
    {
        isActivated = false;
        go_BaseUI.SetActive(false);
    }

}
