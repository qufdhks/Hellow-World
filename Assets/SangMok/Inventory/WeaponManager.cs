using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static bool isChangeWeapon = false;  // ���� ��ü �ߺ� ���� ����. (True�� ���ϰ�)

    [SerializeField]
    private float changeweaponDelayTime;  // ���� ��ü ������ �ð�. ���� ������ ���� �� ���� �ִ� �� �ð�. �뷫 Weapon_Out �ִϸ��̼� �ð�.
    [SerializeField]
    private float changeweaponEndDelayTime;  // ���� ��ü�� ������ ���� ����. �뷫 Weapon_In �ִϸ��̼� �ð�.

    //[SerializeField]
    //private Gun[] guns;  // ��� ������ ���� ���ҷ� ������ �迭
    //[SerializeField]
    //private Hand[] hands;  // ��� ������ Hand �� ���⸦ ������ �迭

    //// ���� �������� �̸����� ���� ���� ������ �����ϵ��� Dictionary �ڷ� ���� ���.
    //private Dictionary<string, Gun> gunDictionary = new Dictionary<string, Gun>();
    //private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    [SerializeField]
    private string currentWeaponType;  // ���� ������ Ÿ�� (��, ���� ���)
    public static Transform currentWeapon;  // ���� ����. static���� �����Ͽ� ���� ��ũ��Ʈ���� Ŭ���� �̸����� �ٷ� ������ �� �ְ� ��.
    public static Animator currentWeaponAnim; // ���� ������ �ִϸ��̼�. static���� �����Ͽ� ���� ��ũ��Ʈ���� Ŭ���� �̸����� �ٷ� ������ �� �ְ� ��.

    //[SerializeField]
    //private GunController theGunController;  // �� �϶� ??GunController.cs Ȱ��ȭ, ���� �� ??GunController.cs ��Ȱ��ȭ 
    //[SerializeField]
    //private HandController theHandController; // �� �϶� ??HandController.cs Ȱ��ȭ, ??HandController.cs ��Ȱ��ȭ

    void Start()
    {
      
    }

    void Update()
    {
        //if (!isChangeWeapon)
        //{

        //    if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 ������ '�Ǽ�'���� ���� ��ü ����
        //    {
        //        StartCoroutine(ChangeWeaponCoroutine("HAND", "�Ǽ�"));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 ������ '���� �ӽŰ�'���� ���� ��ü ����
        //    {
        //        StartCoroutine(ChangeWeaponCoroutine("GUN", "SubMachineGun1"));
        //    }


        //}
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true;
        currentWeaponAnim.SetTrigger("Weapon_Out");

        yield return new WaitForSeconds(changeweaponDelayTime);

        CancelPreWeaponAction();
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeweaponEndDelayTime);

        currentWeaponType = _type;
        isChangeWeapon = false;
    }

    private void CancelPreWeaponAction()
    {
        //switch (currentWeaponType)
        //{
        //    case "GUN":
        //        theGunController.CancelFineSight();
        //        theGunController.CancelReload();
        //        GunController.isActivate = false;
        //        break;
        //    case "HAND":
        //        HandController.isActivate = false;
        //        break;
        //}
    }

    private void WeaponChange(string _type, string _name)
    {
        //if (_type == "GUN")
        //{
        //    theGunController.GunChange(gunDictionary[_name]);
        //}
        //else if (_type == "HAND")
        //{
        //    theHandController.HandChange(handDictionary[_name]);
        //}
    }
}
