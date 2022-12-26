using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TalkManager talkMng;
    [SerializeField] private QuestManager questMng;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject scanObject;
    [SerializeField] private GameObject menuSet;

    [SerializeField] private Animator talkPanel;
    [SerializeField] private TypeEffect talk;
    [SerializeField] private Text questText;
    [SerializeField] private Text npcName;
    [SerializeField] private bool isAction;
    [SerializeField] private int talkIndex;

    public bool GetisAction { get { return isAction; } }

    void Start()
    {
        GameLoad();

        questText.text = "퀘스트 : " + questMng.CheckQuest();
    }

    private void Update()
    {
        // SubMenu ON/OFF
        if (Input.GetButtonDown("Cancel"))
            menuSet.SetActive(!menuSet.activeSelf);
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc, objData.npcName);
        
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int _id, bool _isNpc, string _npcName)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questMng.GetQuestTalkIndex(_id);
            talkData = talkMng.GetTalk(_id + questTalkIndex, talkIndex);
        }

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = "퀘스트 : " + questMng.CheckQuest(_id);
            return;
        }

        if (_isNpc)
        {
            talk.SetMsg(talkData);
            npcName.text = _npcName;
        }
        else
        {
            talk.SetMsg(talkData);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        // 플레이어 위치
        PlayerPrefs.SetFloat("Player X", player.transform.position.x);
        PlayerPrefs.SetFloat("Player Y", player.transform.position.y);
        PlayerPrefs.SetFloat("Player Z", player.transform.position.z);

        // 퀘스트 정보
        PlayerPrefs.SetInt("Quest ID", questMng.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questMng.GetquestActionIndex);

        //인벤토리

        //PlayerPrefs.Save();
        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Player X")) 
            return;

        Debug.Log("Loading");
        float x = PlayerPrefs.GetFloat("Player X");
        float y = PlayerPrefs.GetFloat("Player Y");
        float z = PlayerPrefs.GetFloat("Player Z");

        int questId = PlayerPrefs.GetInt("Quest ID");
        int questActionindex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, z);
        questMng.questId = questId;
        questMng.GetquestActionIndex = questActionindex;
        questMng.ControllObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
