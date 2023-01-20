using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    [Header("���� ���� ����")]
    public Transform[] points; //���� ��ġ
    public GameObject enemy;
    public float createTime = 2f;//���� �ֱ�
    public int maxEnemy = 1;

    public bool isGameOver = false;
    //�̱��Ͽ� �����ϱ� ���� static ���� 
    //static�� ���� è�Ǿ� ������ �ʾƵ� ��ΰ� �� �� �ִ� ����
    public static ObjPooling instance;

    [SerializeField] private Transform look;

    [SerializeField] private fishing fishing;

    private void Awake()
    {
        if (instance == null)
        {
            //�ش� ���� �Ŵ���(�ڱ��ڽ�)�� �Ҵ�
            instance = this;
        }
        //instance�� �Ҵ�� Ŭ������ �ڱ� �ڽ��� �ƴ϶�� ���� ������ Ŭ������ �ǹ��� �ᱹ Ŭ���� üũ�ϴ�������
        //����ũ�ϰ� �ش� ���ӿ� GameManger�� �ϳ��� �����ϵ��� �Ϸ���
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //�� ������ �Ͼ���� �������� �ʰ� ��� ����
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (points.Length > 0)
        {
            //Enemy �ڵ� ���� �ڷ�ƾ �Լ� ȣ��
            StartCoroutine(CreatEnemy());
        }
        //DontDestroyOnLoad(gameObject);
    }


    IEnumerator CreatEnemy()
    {
        //���� ���� ������ ���ѷ���
        //while (!isGameOver)
        while (true)
        {
            //ENEMY �±׸� ���� ������Ʈ�� ���� �ľ�
            //�ִ� 10������ �ѱ��� �ʱ� ���ؼ�
            GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
            if (fishes == null || fishes.Length == 0)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(0, points.Length);
                GameObject  go = Instantiate(enemy,//Enemy, ������
                            points[idx].position,//��������� ��ġ
                            points[idx].rotation);//��������� ��ġ�� ȸ����
                go.GetComponent<TargetFish>().Init(look, fishing);

                fishing.SetAttachGo(go);
            }
           // else
                yield return null;
        }
    }
}
