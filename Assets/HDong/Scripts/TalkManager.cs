using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "�츮 ���� �°� ȯ����" });
        talkData.Add(2000, new string[] { "���.", "���� �ʿ��� �� �־�?" });
        talkData.Add(4000, new string[] { "�ȳ�! OO��, ���� �� �ѷ��þ�?" });
        // ���� NPC
        talkData.Add(8000, new string[] { "�����ҷ�?" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "���� �Ͼ����", "����� OO�����̾�\n�غ����� ������ �ֱ淡 �����Ծ�.", 
                                                "�ϴ� ������ ������ �ۿ� ������ OO�̸� ã�ƺ�\n������ �ٰž�." });
        talkData.Add(11 + 1000, new string[] { "���� OO�̸� ��ã���ž�?\n������ ������ �������̾�." });
        talkData.Add(11 + 2000, new string[] { "�ʰ� OO�̰� ���� �ֱ���?", "�ϴ� �� �������� �����Ϸ��� ������ �ʿ��ϰ���?", 
                                                "�ֺ����� �� 3���� �������� 3���� �ֿ�����\n���� ������ ����� �ٰ�." });


        talkData.Add(20 + 2000, new string[] { "���������� �����̴� ���� ���̻��̿� ���� ������ �����ž�." });
        talkData.Add(20 + 1000, new string[] { "���� �����̸� �ٰ�(�׽�Ʈ��)" });
        talkData.Add(21 + 2000, new string[] { "��� ã�ƿԱ���.", "�ֿ��� ���������� �����̷� ���� ������ ������ٰ�.", "��.\n������ ���� ������ ��� �볪���� ���� �� �����ž�.",
                                               "�ٸ��� �ǳʸ� ã�� �� �ִ� OO�̸� ã�ư���.\n�ٸ� ���� �ٰž�."});
        
        talkData.Add(30 + 4000, new string[] { "OO�������� �پ��� ������� ģ���� ���� �ְ� \n���׸��� ��ǰ�� ������ ���� �־�.", "���� �� ������ ���״� �������� ���� 20���� ���ؿ���." });

        //�繰
        //talkData.Add(100, new string[] { "������ �� �� ����" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}