using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Crafting.ResourceItem resourceType;

    private void OnMouseDown()
    {
        switch(resourceType)
        {
            case Crafting.ResourceItem.STONE:
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Crafting>().stone++;
                break;
            case Crafting.ResourceItem.WOOD:
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Crafting>().wood++;
                break;
                
        }
        Destroy(gameObject);

    }

}
