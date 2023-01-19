using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPooling : MonoBehaviour
{

    [Header("�� ���� ����")]
    public Transform[] points; //���� ��ġ
    public GameObject DesRock;
    public float createTime = 5f;//���� �ֱ�
    public int maxRock = 10;

    public bool isGameOver = false;

    public static RockPooling instance;

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
            StartCoroutine(CreatRock());
        }
        
    }

    IEnumerator CreatRock()
    {
        //���� ���� ������ ���ѷ���
        //while (!isGameOver)
        while (true)
        {
            //ENEMY �±׸� ���� ������Ʈ�� ���� �ľ�
            //�ִ� 10������ �ѱ��� �ʱ� ���ؼ�
            GameObject[] Rocks = GameObject.FindGameObjectsWithTag("Rock");
            if (Rocks == null || Rocks.Length == 0)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(0, points.Length);
                GameObject goRock = Instantiate(DesRock,//Enemy, ������
                            points[idx].position,//��������� ��ġ
                            points[idx].rotation);//��������� ��ġ�� ȸ����
              
            }
            yield return null;
        }
    }
}
