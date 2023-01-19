using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public static Rock Instance;

    [SerializeField]
    private int hp; // ������ ü��. 0 �� �Ǹ� �ı���

    [SerializeField]
    private int destroyTime; // �ı��� ������ ������� ���� (�� �ð��� ������ Destroy)

    [SerializeField]
    private BoxCollider col; // ��ü �ݶ��̴�. ���� �ı���Ű�� ��Ȱ��ȭ��ų ��.

    [SerializeField]
    private GameObject go_rock;  // �Ϲ� ���� ������Ʈ. ��ҿ� Ȱ��ȭ, ���� ������ ��Ȱ��ȭ
    [SerializeField]
    private GameObject go_debris;  // ���� ���� ������Ʈ. ��ҿ� ��Ȱ��ȭ, ���� ������ Ȱ��ȭ

    [SerializeField]
    public GameObject stone;
    public Transform stonePos;

    //[SerializeField]
    public GameObject DestroyRock;
    //public Transform DesRockPos;

    public void Mining()//ä��
    {

        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Update()
    {
        
    }
    private void Destruction() //ü���� 0�� �Ǹ� �ı�
    {
        col.enabled = false;
        //Destroy(go_rock);
        //go_rock.SetActive(false);

        //go_debris.SetActive(true);
        //Destroy(go_debris, destroyTime);
        //Invoke("delayRock", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Debug.Log("ä������");
            Mining();
            GameObject _stone = Instantiate(stone, stonePos.position, Quaternion.identity);
            StartCoroutine(cloneRock(_stone.transform.position));
        }
    }

    
    IEnumerator cloneRock(Vector3 _position)
    {
        yield return new WaitForSeconds(10f);
        col.enabled = true;
        go_rock.SetActive(true);
        GameObject _rock = Instantiate(go_debris, _position, Quaternion.identity);
        Destroy(_rock, 1f);
        //go_debris.SetActive(true);
    }

    //void delayRock()
    //{
    //    go_debris.SetActive(false);
    //}


}
