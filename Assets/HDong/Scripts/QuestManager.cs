using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public int GetquestActionIndex { get { return questActionIndex; } set { questActionIndex = value; } }

    //[SerializeField] private GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("의문의 마을", new int[] {1000}));
        questList.Add(20, new QuestData("마을 적응하기(1)", new int[] {2000, 2000}));
        questList.Add(30, new QuestData("마을 적응하기(2)", new int[] {4000}));
        questList.Add(40, new QuestData("마을 적응하기(3)", new int[] {5000, 5000}));
        questList.Add(50, new QuestData("퀘스트 올 클리어" , new int[] {0}));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //ControllObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    //public void ControllObject()
    //{
    //    switch (questId)
    //    {
    //        case 10:
    //            if (questActionIndex == 2)
    //                questObject[0].SetActive(true);
    //            break;
    //        case 20:
    //            if (questActionIndex == 0)
    //                questObject[0].SetActive(true);
    //            else if (questActionIndex == 1)
    //                questObject[0].SetActive(false);
    //            break;
    //    }
    //}
}
