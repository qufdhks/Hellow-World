using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public delegate int GoCraft(int _dimi, int _val);
    private GoCraft craft = null;

    [SerializeField] private CraftInformation information;
    [SerializeField] private GameObject slotParent;
    private Inventory inventory;

    private Slot[] slots;

    public enum ResourceItem { WOOD, STONE, SPIDERWEB };

    private int craft1;
    private int craft2;

    private int count;
    private int need1;
    private int need2;

    [SerializeField] private Image[] images;
    [SerializeField] private Text itemName;
    [SerializeField] private GameObject craftWindow;

    public Text item1Text;
    public Text item2Text;

    bool crafting = false;

    private void Awake()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (information != null)
        {
            GetCheck();
            item1Text.text = craft1.ToString() + "/" + information.needCount[0].ToString();
            item2Text.text = craft2.ToString() + "/" + information.needCount[1].ToString();
            need1 = information.needCount[0];
            need2 = information.needCount[1];
        }

        if (craftWindow.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            craftWindow.SetActive(false);
    }

    void GetCheck()
    {
        if (crafting)
            craft = GoingCraft;

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
                            count = slots[i].RemoveCount(need1);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }
            craft1 = count;

            if (craft1 < information.needCount[0])
                item1Text.color = Color.red;
            else
                item1Text.color = Color.white;
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
                            count = slots[i].RemoveCount(need1);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }

            craft1 = count;

            if (craft1 < information.needCount[0])
                item1Text.color = Color.red;
            else
                item1Text.color = Color.white;
        }
        else if (information.needImage[0].name == "spiderweb")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "spiderweb")
                    {
                        if (crafting)
                        {
                            count = slots[i].RemoveCount(need1);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }

            craft1 = count;

            if (craft1 < information.needCount[0])
                item1Text.color = Color.red;
            else
                item1Text.color = Color.white;
        }
        else
            craft1 = 0;

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
                            count = slots[i].RemoveCount(need2);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }

            craft2 = count;

            if (craft2 < information.needCount[1])
                item2Text.color = Color.red;
            else
                item2Text.color = Color.white;
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
                            count = slots[i].RemoveCount(need2);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }

            craft2 = count;

            if (craft2 < information.needCount[1])
                item2Text.color = Color.red;
            else
                item2Text.color = Color.white;
        }
        else if (information.needImage[1].name == "spiderweb")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].itemImage.sprite.name == "spiderweb")
                    {
                        if (crafting)
                        {
                            count = slots[i].RemoveCount(need2);
                            break;
                        }
                        else
                        {
                            count = slots[i].itemCount;
                            break;
                        }
                    }
                }
                else
                    count = 0;
            }

            craft2 = count;

            if (craft2 < information.needCount[1])
                item2Text.color = Color.red;
            else
                item2Text.color = Color.white;
        }
        else
            craft2 = 0;

        crafting = false;
    }

    int GoingCraft(int _dimi,int _val)
    {
        if (crafting)
            _dimi -= _val;

        return _dimi;
    }

   public void OnClick(CraftInformation _information)
    {

        if(!craftWindow.activeSelf)
            craftWindow.SetActive(true);

        information = _information;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = information.needImage[i];
            images[i].name = information.needImage[i].name;
        }
        itemName.text = information.itemName;
        
        GetCheck();
    }

    public void CraftByInt()
    {
        if (craft1 >= need1 && craft2 >= need2)
        {
            Debug.Log("????");
            crafting = true;
            GetCheck();
            inventory.AcquireItem(information.item);
        }
    }
}
