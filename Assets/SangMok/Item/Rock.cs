using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
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

    [SerializeField]
    public GameObject DesRock;
    public Transform DesRockPos;

    public void Mining()//ä��
    {
        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Destruction() //ü���� 0�� �Ǹ� �ı�
    {
        col.enabled = false;
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destroyTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Debug.Log("ä������");
            Mining();
            Instantiate(stone, stonePos.position, Quaternion.identity);
            Invoke("InstanRock", 2f);
            
        }
    }

    private void InstanRock()
    {
        Instantiate(DesRock, DesRockPos.position, Quaternion.identity);
    }
}
