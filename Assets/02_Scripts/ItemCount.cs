using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    private Inventory inventory;
    private Slot[] slots;
    private Text text;

    [SerializeField] private int needCount;

    private void OnEnable()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        slots = inventory.slots;
        text = transform.GetChild(0).GetComponent<Text>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null && slots[i].item.itemName == gameObject.name)
            {
                Debug.Log("dd");
                text.text = slots[i].itemCount.ToString() + "/" + needCount;
                break;
            }
            else
                text.text = "0" + "/" + needCount;
        }
    }
}
