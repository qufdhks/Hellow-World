using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    public float range;  // ������ ������ ������ �ִ� �Ÿ�

    public bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    [SerializeField]
    public LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.

    [SerializeField]
    public Text actionText;  // �ൿ�� ���� �� �ؽ�Ʈ
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
        actionText.text = other.transform.GetComponent<ItemPickUp>().Getitem.itemName + " ȹ�� " + "<color=red>" + "(B)" + "</color>";
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
                Debug.Log(other.GetComponent<ItemPickUp>().Getitem.itemName + " ȹ�� �߽��ϴ�.");  // �κ��丮 �ֱ�
                theInventory.AcquireItem(other.GetComponent<ItemPickUp>().Getitem);
                Destroy(other.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }

}