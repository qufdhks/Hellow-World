using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDokam : MonoBehaviour
{
    public bool pickupActivated = false;


    [SerializeField]
    public LayerMask layerMask;  // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다

    [SerializeField]
    public Text actionText;  // 행동을 보여 줄 텍스트
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
        actionText.text = other.transform.GetComponent<ItemPickUp>().Getitem.itemName + " 획득 " + "<color=red>" + "(P)" + "</color>";
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
                Debug.Log(other.GetComponent<ItemPickUp>().Getitem.itemName + " 획득 했습니다.");  // 도감 넣기
                theencyclopedia.AcquireItem(other.GetComponent<ItemPickUp>().Getitem);
                Destroy(other.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
