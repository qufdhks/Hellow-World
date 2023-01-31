using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Craft
{
    public string craftName;//�̸�
    public GameObject go_Prefab;//��ġ�� ������
    public GameObject go_PreviewPrefab;//�̸����� ������
}

public class CraftManual : MonoBehaviour
{
    [Header("��� ����")]
    [SerializeField] private GameObject slotParent;
    private Slot[] slots;
    CraftInformation information;
    [SerializeField] int need1, need2, item1, item2;
    bool crafting;

    //���º���
    public bool clearQuest = false;
    public static bool isActivated = false;
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_BaseUI;//�⺻ ���̽� UI

    [SerializeField]
    private Craft[] craft_house;//������ ��

    private GameObject go_Preview;//������ �̸����� ���� ����
    private GameObject go_Prefab;// ���� ������ �������� ���� ����


    [SerializeField]
    private Transform tf_Player;//�÷��̾� ��ġ

    [SerializeField] private Text failText;

    //private RaycastHit hitinfo;

    //[SerializeField]
    //private LayerMask layerMask;

    //[SerializeField]
    //private float range;

    private void Awake()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    //����
    public void SlotClick(CraftInformation _information)
    {
        information = _information;
        CheckItem();
        need1 = information.needCount[0];
        need2 = information.needCount[1];
        if (!(item1 >= need1 && item2 >= need2))
        {
            StartCoroutine(TextControll());
            CloseWindow();
            return;
        }

        go_Preview = Instantiate(craft_house[_information.count].go_PreviewPrefab, tf_Player.position + (tf_Player.forward * 1f) + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
        go_Prefab = craft_house[_information.count].go_Prefab;
        isPreviewActivated = true;
        go_BaseUI.SetActive(false);
    }

    //public void SlotClick(int _slotNumber)
    //{
    //    Debug.Log("Ŭ����");
    //    go_Preview = Instantiate(craft_house[_slotNumber].go_PreviewPrefab, tf_Player.position + tf_Player.forward, Quaternion.identity);
    //    go_Prefab = craft_house[_slotNumber].go_Prefab;
    //    isPreviewActivated = true;
    //    go_BaseUI.SetActive(false);
    //}


    void Start()
    {
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPreviewActivated /*&& clearQuest*/)
        {
            Window();
        }

        if (Input.GetKeyDown(KeyCode.B) && information != null)
        {
            CheckItem();
            if (item1 >= need1 && item2 >= need2)
                Build();
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
        }
    }

    //����
    private void Build()
    {
        if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().IsBuildable())
        {
            crafting = true;
            CheckItem();

            Instantiate(go_Prefab, tf_Player.position + (tf_Player.forward * 5f) + new Vector3(0f, 0f, 0f), Quaternion.identity);
            Destroy(go_Preview);
            isActivated = false;
            isPreviewActivated = false;
            go_Preview = null;
            go_Prefab = null;
            information = null;
        }
    }

    //out
    //private void Build()
    //{
    //    if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().IsBuildable())
    //    {
    //        Instantiate(go_Prefab, hitinfo.point, Quaternion.identity);
    //        Destroy(go_Preview);
    //        isActivated = false;
    //        isPreviewActivated = false;
    //        go_Preview = null;
    //        go_Prefab = null;
    //    }
    //}

    //out
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

    private void CheckItem()
    {
        if (information.needImage[0].name == "stone")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "stone")
                    {
                        if (crafting)
                        {
                            item1 = slots[i].RemoveCount(need1);
                            break;
                        }
                        else
                        {
                            item1 = slots[i].itemCount;
                            break;
                        }
                    }
                }
            }
        }
        else if (information.needImage[0].name == "wood")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "wood")
                    {
                        if (crafting)
                        {
                            item1 = slots[i].RemoveCount(need1);
                            break;
                        }
                        else
                        {
                            item1 = slots[i].itemCount;
                            break;
                        }
                    }
                }
            }
        }
        else
            item1 = 0;

        if (information.needImage[1].name == "stone")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "stone")
                    {
                        if (crafting)
                        {
                            item2 = slots[i].RemoveCount(need2);
                            break;
                        }
                        else
                        {
                            item2 = slots[i].itemCount;
                            break;
                        }
                    }
                }
            }
        }
        else if (information.needImage[1].name == "wood")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "wood")
                    {
                        if (crafting)
                        {
                            item2 = slots[i].RemoveCount(need2);
                            break;
                        }
                        else
                        {
                            item2 = slots[i].itemCount;
                            break;
                        }
                    }
                }
            }
        }
        else
            item2 = 0;

        crafting = false;
    }

    IEnumerator TextControll()
    {
        failText.text = "��ᰡ �����մϴ�.";
        yield return new WaitForSeconds(1f);
        failText.text = "";
    }

}
