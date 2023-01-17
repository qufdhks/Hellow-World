using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Craft
{
    public string craftName;//�̸�
    public GameObject go_Prefab;//��ġ�� ������
    public GameObject go_PreviewPrefab;//�̸����� ������
}

public class CraftManual : MonoBehaviour
{
    //���º���
    public bool clearQuest = false;
    private bool isActivated = false;
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_BaseUI;//�⺻ ���̽� UI

    [SerializeField]
    private Craft[] craft_house;//������ ��

    private GameObject go_Preview;//������ �̸����� ���� ����
    private GameObject go_Prefab;// ���� ������ �������� ���� ����


    [SerializeField]
    private Transform tf_Player;//�÷��̾� ��ġ

    //private RaycastHit hitinfo;
    
    [SerializeField]
    private LayerMask layerMask;

    //[SerializeField]
    //private float range;


    public void SlotClick(int _slotNumber)
    {
        Debug.Log("Ŭ����");
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
