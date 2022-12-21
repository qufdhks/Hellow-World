using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TalkManager talkMng;
    [SerializeField] private QuestManager questMng;

    [SerializeField] Animator talkPanel;
    [SerializeField] private Text talkText;
    [SerializeField] private GameObject scanObject;
    [SerializeField] private bool isAction;
    [SerializeField] private int talkIndex;

    public bool GetisAction { get { return isAction; } }

    void Start()
    {
        Debug.Log(questMng.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questMng.GetQuestTalkIndex(id);
        string talkData = talkMng.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questMng.CheckQuest(id));
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }
}
