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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stoneText.text = stone.ToString();
        woodText.text = wood.ToString();
    }
}
