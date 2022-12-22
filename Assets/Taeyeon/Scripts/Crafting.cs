using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    [SerializeField] private CraftInformation information;

    public enum CraftableItem { AXE};
    public enum ResourceItem { WOOD, STONE, SPIDERWEB };

    public int wood;
    public int stone;
    public int spiderweb;

    private int craft1;
    private int craft2;


    //int count = 3;
    [SerializeField] private Image[] images;
    [SerializeField] private Text name;

    public Text stoneText;
    public Text woodText;

    public bool hasAxe;

    public GameObject axeButton;
    

    // Update is called once per frame
    void Update()
    {
        if (information != null)
        {
            GetCheck();
            stoneText.text = craft1.ToString() + "/" + information.needCount[0].ToString();
            woodText.text = craft2.ToString() + "/" + information.needCount[1].ToString();
        }
    }

    void GetCheck()
    {
        if (information.needImage[0].name == "stone")
            craft1 = stone;
        else if (information.needImage[0].name == "wood")
            craft1 = wood;

        if (information.needImage[1].name == "stone")
            craft2 = stone;
        else if (information.needImage[1].name == "wood")
            craft2 = wood;
    }

    public void OnClick(CraftInformation _information)
    {
        information = _information;
        for(int i = 0; i < images.Length; i++)
            images[i].sprite = information.needImage[i];
        name.text = information.name;
    }

    public void CraftByInt(int craftInt)
    {
        if(craftInt ==1)
        {
            Craft(CraftableItem.AXE);

        }
    }
    public bool Craft(CraftableItem craftable)
    {
        bool success = false;

        switch(craftable)
        {
            case CraftableItem.AXE:
                if(wood >= 1 && stone >= 2)
                {
                    success = true;
                    wood -= 1;
                    stone -= 2;
                    hasAxe = true;
                }
                break; 
        }

        return success;
    }
}
