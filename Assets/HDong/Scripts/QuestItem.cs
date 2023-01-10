using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    [SerializeField] private int[] questId;

    private ObjData objdata;

    public Dictionary<int, ObjData.SQuestItem> questItem;

    private void Awake()
    {
        objdata = GetComponent<ObjData>();
    }

    private void Start()
    {
        for (int i = 0; i < questId.Length; i++)
        {
            questItem.Add(questId[i], objdata.items[i]);
        }
    }
}