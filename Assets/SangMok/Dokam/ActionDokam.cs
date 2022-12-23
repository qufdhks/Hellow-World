using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDokam : MonoBehaviour
{
    public bool pickupActivated = false;


    [SerializeField]
    public LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�

    [SerializeField]
    public Text actionText;  // �ൿ�� ���� �� �ؽ�Ʈ
    public Encyclopedia theencyclopedia;

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Bug")
        {
            Debug.Log("ddddd");
            ItemInfoAppear(other);
            if (Input.GetKeyDown(KeyCode.P))
            {
                //CheckItem();
                CanPickUp(other);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Bug")
        {
            ItemInfoDisappear();
        }
    }


    private void ItemInfoAppear(Collider other)
    {
        pickupActivated = true;
        Debug.Log(pickupActivated);
        actionText.gameObject.SetActive(true);
        actionText.text = other.transform.GetComponent<ItemPickUp>().Getitem.itemName + " ȹ�� " + "<color=red>" + "(P)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp(Collider other)
    {
        if (pickupActivated)
        {
            if (other != null)
            {
                Debug.Log(other.GetComponent<ItemPickUp>().Getitem.itemName + " ȹ�� �߽��ϴ�.");  // ���� �ֱ�
                theencyclopedia.AcquireItem(other.GetComponent<ItemPickUp>().Getitem);
                Destroy(other.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
