using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //[SerializeField] private int id;
    //[SerializeField] private bool isNpc;
    public int id;
    public string npcName;
    public bool isNpc;
    public int needliking;

    [System.Serializable]
    public struct SQuestItem
    {
        public Item item;
        public int num;
    }

    public SQuestItem[] items = null;

    //public int Getid { get { return id; } }
    //public bool GetisNpc { get { return isNpc; } }
}
