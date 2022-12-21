using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{

    public enum CraftableItem { AXE};
    public enum ResourceItem { WOOD, STONE };

    public int wood;
    public int stone;

    public Text stoneText;
    public Text woodText;

    public bool hasAxe;

    public GameObject axeButton;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stoneText.text = stone.ToString();
        woodText.text = wood.ToString();
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
