using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    //[SerializeField]
    //GameObject Hand, Axe, Pickaxe;
    [SerializeField]
    private GameObject[] weapon;

    [SerializeField]
    private Slot[] slots;
    
    void Start()
    {
        SwapWeapon(1);
    }

    
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Alpha1))
        {
                Debug.Log("¹«±âÀåÂø");
                SwapWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
                Debug.Log("¹«±âÀåÂø");
                SwapWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
                Debug.Log("¹«±âÀåÂø");
                SwapWeapon(3);
        }
    }

    void SwapWeapon(int weaponType)
    {
        if (slots[weaponType - 1].item != null)
        {
            if (slots[weaponType - 1].item.itemName == "Axe")
            {
                for (int i = 0; i < weapon.Length; i++)
                {
                    if (weapon[i].name == "Axe")
                        weapon[i].SetActive(true);
                    else
                        weapon[i].SetActive(false);
                }
            }
            else if (slots[weaponType - 1].item.itemName == "Pickaxe")
            {
                for (int i = 0; i < weapon.Length; i++)
                {
                    if (weapon[i].name == "Pickaxe")
                        weapon[i].SetActive(true);
                    else
                        weapon[i].SetActive(false);
                }
            }
        }
        else
        {
            Debug.Log("Hand");
            for (int i = 0; i < weapon.Length; i++)
            {
                if (weapon[i].name == "Hand")
                    weapon[i].SetActive(true);
                else
                    weapon[i].SetActive(false);
            }
        }

        //if(weaponType == 1)
        //{
        //    Hand.SetActive(true);
        //    Axe.SetActive(false);
        //    Pickaxe.SetActive(false);

        //    weaponSelected = 1;
        //}
        //if (weaponType == 2)
        //{
        //    Hand.SetActive(false);
        //    Axe.SetActive(true);
        //    Pickaxe.SetActive(false);

        //    weaponSelected = 2;
        //}
        //if (weaponType == 3)
        //{
        //    Hand.SetActive(false);
        //    Axe.SetActive(false);
        //    Pickaxe.SetActive(true);

        //    weaponSelected = 3;
    }
}

