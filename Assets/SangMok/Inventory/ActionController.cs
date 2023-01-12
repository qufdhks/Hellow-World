using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    public float range;  // 아이템 습득이 가능한 최대 거리

    public bool pickupActivated = false;  // 아이템 습득 가능할시 True 

    [SerializeField]
    public LayerMask layerMask;  // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다.

    [SerializeField]
    public Text actionText;  // 행동을 보여 줄 텍스트
    public Inventory theInventory;

    void Update()
    {
        //CheckItem();
        //TryAction();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Item")
        {
            ItemInfoAppear(other);
            if (Input.GetKeyDown(KeyCode.B))
            {
                //CheckItem();
                CanPickUp(other);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Item")
        {
            ItemInfoDisappear();
        }
    }

    //private void CheckItem()
    //{
    //    if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
    //    {
    //        if (hitInfo.transform.tag == "Item")
    //        {
    //            ItemInfoAppear();
    //        }
    //    }
    //    else
    //        ItemInfoDisappear();
    //}

    private void ItemInfoAppear(Collider other)
    {
        pickupActivated = true;
        //Debug.Log(pickupActivated);
        actionText.gameObject.SetActive(true);
        actionText.text = other.transform.GetComponent<ItemPickUp>().Getitem.itemName + " 획득 " + "<color=red>" + "(B)" + "</color>";
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
                Debug.Log(other.GetComponent<ItemPickUp>().Getitem.itemName + " 획득 했습니다.");  // 인벤토리 넣기
                theInventory.AcquireItem(other.GetComponent<ItemPickUp>().Getitem);
                Destroy(other.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }

}