using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Crafting.ResourceItem resourceType;

    [SerializeField] private Crafting inventory;

    private void OnMouseDown()
    {
        switch(resourceType)
        {
            case Crafting.ResourceItem.STONE:
                inventory.stone++;
                break; 
            case Crafting.ResourceItem.WOOD:
                inventory.wood++;
                break;
            case Crafting.ResourceItem.SPIDERWEB:
                inventory.spiderweb++;
                break;
        }   
        Destroy(gameObject);

    }

}
