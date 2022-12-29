using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public delegate int GoCraft(int _dimi, int _val);
    private GoCraft craft = null;

    [SerializeField] private CraftInformation information;
    private CraftInformation Getinformation;

    public enum CraftableItem { AXE};
    public enum ResourceItem { WOOD, STONE, SPIDERWEB };

    public int wood;
    public int stone;
    public int spiderweb;

    private int craft1;
    private int craft2;

    private int need1;
    private int need2;

    [SerializeField] private Image[] images;
    [SerializeField] private Text name;
    [SerializeField] private GameObject craftWindow;

    public Text stoneText;
    public Text woodText;

    bool crafting = false;
    public bool hasAxe;

    public GameObject axeButton;

    void Update()
    {
        if (information != null)
        {
            GetCheck();
            stoneText.text = craft1.ToString() + "/" + information.needCount[0].ToString();
            woodText.text = craft2.ToString() + "/" + information.needCount[1].ToString();
            need1 = information.needCount[0];
            need2 = information.needCount[1];
        }
    }

    void GetCheck()
    {
        if (crafting)
            craft = GoingCraft;


        if (information.needImage[0].name == "stone")
        {
            if (craft != null)
                stone = GoingCraft(stone, need1);
            craft1 = stone;
        }

        else if (information.needImage[0].name == "wood")
        {
            if (craft != null)
                wood = GoingCraft(wood, need1);
            craft1 = wood;
        }
        else if (information.needImage[0].name == "spiderweb")
        {
            if (craft != null)
                spiderweb = GoingCraft(spiderweb, need1);
            craft1 = spiderweb;
        }


        if (information.needImage[1].name == "stone")
        {
            if (craft != null)
                stone = GoingCraft(stone, need2);
            craft2 = stone;
        }
        else if (information.needImage[1].name == "wood")
        {
            if (craft != null)
                wood = GoingCraft(wood, need2);
            craft2 = wood;
        }
        else if (information.needImage[1].name == "spiderweb")
        {
            if (craft != null)
                spiderweb = GoingCraft(spiderweb, need2);
            craft1 = spiderweb;
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
        Getinformation = information;
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
                    hasAxe = true;
                }
                break; 

        }

        return success;
    }
}
