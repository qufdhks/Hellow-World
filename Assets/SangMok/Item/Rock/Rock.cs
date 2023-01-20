using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public static Rock Instance;

    [SerializeField]
    private int hp; // 바위의 체력. 0 이 되면 파괴됨

    [SerializeField]
    private int destroyTime; // 파괴된 바위의 파편들의 생명 (이 시간이 지나면 Destroy)

    [SerializeField]
    private BoxCollider col; // 구체 콜라이더. 바위 파괴시키면 비활성화시킬 것.

    [SerializeField]
    private GameObject go_rock;  // 일반 바위 오브젝트. 평소에 활성화, 바위 깨지면 비활성화
    [SerializeField]
    private GameObject go_debris;  // 깨진 바위 오브젝트. 평소에 비활성화, 바위 깨지면 활성화

    [SerializeField]
    public GameObject stone;
    public Transform stonePos;

    //[SerializeField]
    public GameObject DestroyRock;
    //public Transform DesRockPos;

    public void Mining()//채굴
    {

        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Update()
    {
        
    }
    private void Destruction() //체력이 0이 되면 파괴
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
            Debug.Log("채굴성공");
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
