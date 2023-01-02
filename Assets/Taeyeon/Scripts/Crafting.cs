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

    private Slot[] slots;

    public enum CraftableItem { AXE};
    public enum ResourceItem { WOOD, STONE, SPIDERWEB };

    private int craft1;
    private int craft2;

    private int count;
    private int need1;
    private int need2;

    [SerializeField] private Image[] images;
    [SerializeField] private Text name;
    [SerializeField] private GameObject craftWindow;

    public Text item1Text;
    public Text item2Text;

    bool crafting = false;

    private void Awake()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
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
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemImage.sprite.name == "stone")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need1);
                    count = slots[i].itemCount;
                }
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
                if (slots[i].itemImage.sprite.name == "wood")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need1);
                    count = slots[i].itemCount;
                }
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
                if (slots[i].itemImage.sprite.name == "spiderweb")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need1);
                    count = slots[i].itemCount;
                }
            }

            craft1 = count;

            if (craft1 < information.needCount[0])
                item1Text.color = Color.red;
            else
                item1Text.color = Color.white;
        }


        if (information.needImage[1].name == "stone")
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemImage.sprite.name == "stone")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need2);
                    count = slots[i].itemCount;
                }
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
                if (slots[i].itemImage.sprite.name == "wood")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need2);
                    count = slots[i].itemCount;
                }
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
                if (slots[i].itemImage.sprite.name == "spiderweb")
                {
                    if (craft != null)
                        slots[i].itemCount = GoingCraft(slots[i].itemCount, need2);
                    count = slots[i].itemCount;
                }
            }

            craft2 = count;

            if (craft2 < information.needCount[1])
                item2Text.color = Color.red;
            else
                item2Text.color = Color.white;
        }

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
        for(int i = 0; i < images.Length; i++)
            images[i].sprite = information.needImage[i];
        name.text = information.name;
    }

    public void CraftByInt(int craftInt)
    {
        //craftInt = information.count;

        if(craftInt == 1)
        {
            Craft(CraftableItem.AXE);
        }
    }

    public bool Craft(CraftableItem craftable)
    {
        bool success = false;

        switch (craftable)
        {
            case CraftableItem.AXE:
                if(craft1 >= need1 && craft2 >= need2)
                {
                    Debug.Log(need2);
                    success = true;
                    crafting = true;
                    GetCheck();
                }
                break; 

        }

        return success;
    }
}
