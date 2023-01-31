using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public int GetquestActionIndex { get { return questActionIndex; } set { questActionIndex = value; } }

    [SerializeField] private GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("시험 준비", new int[] {1000}));
        questList.Add(20, new QuestData("마을 적응하기", new int[] {2000, 8000}));
        questList.Add(30, new QuestData("여름", new int[] {8000}));
        questList.Add(40, new QuestData("가을", new int[] {5000, 5000}));
        questList.Add(50, new QuestData("겨울" , new int[] {0}));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        ControllObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControllObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                {
                    questObject[0].SetActive(true);
                    questObject[1].SetActive(true);
                    questObject[2].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(true);
                break;
            case 30:
                if (questActionIndex == 0)
                    questObject[1].SetActive(true);
                break;
            case 40:
                if (questActionIndex == 0)
                    questObject[2].SetActive(true);
                break;

        }
    }
}
