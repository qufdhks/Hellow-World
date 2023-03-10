using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TalkManager talkMng;
    [SerializeField] private QuestManager questMng;
    [SerializeField] private TimeManager timeMng;
    [SerializeField] private CraftManual craftManu;
    [SerializeField] private Inventory inventory;
    private Dictionary<int, ObjData.SQuestItem> questItem;

    private Slot[] slots;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject scanObject;
    [SerializeField] private GameObject menuSet;
    [SerializeField] private GameObject craftingCanvas;
    [SerializeField] private GameObject quickSlot;

    [SerializeField] private Animator talkPanel;
    [SerializeField] private TypeEffect talk;
    [SerializeField] private Text questText;
    [SerializeField] private Text npcName;
    [SerializeField] private bool isAction;
    private bool clearQuest;
    private bool NextQuset;
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
        if (!craftingCanvas.activeSelf && Input.GetButtonDown("Cancel"))
            menuSet.SetActive(!menuSet.activeSelf);
        if (craftingCanvas.activeSelf && Input.GetButtonDown("Cancel"))
            craftingCanvas.SetActive(false);

        if (questMng.questId == 50)
            craftManu.clearQuest = true;
    }

    public void Action(GameObject scanObj)
    {
        if (scanObj != null)
        {
            scanObject = scanObj;
        }
        if (scanObject.GetComponent<QuestItem>() != null) {
            questItem = new Dictionary<int, ObjData.SQuestItem>();
            questItem = scanObject.GetComponent<QuestItem>().questItem; 
        }

        ObjData objData = scanObject.GetComponent<ObjData>();

        if (questItem != null && questItem.ContainsKey(questMng.questId))
        {
            NextQuset = false;
            clearQuest = true;
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item == null) continue;

                if (questItem[questMng.questId].item.itemName == inventory.slots[i].item.itemName)
                {
                    if (questItem[questMng.questId].num <= inventory.slots[i].itemCount)
                    {
                        NextQuset = true;
                        break;
                    }
                }
                continue;
            }
        }
        else
            clearQuest = false;

        Talk(objData.id, objData.isNpc, objData.npcName);

        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int _id, bool _isNpc, string _npcName)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (NextQuset)
        {
            questMng.NextQuest();
            NextQuset = false;
            clearQuest = true;

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
        else
        {


            quickSlot.SetActive(false);

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

                if (!clearQuest)
                {
                    questText.text = "퀘스트명 : " + questMng.CheckQuest(_id);
                }

                if (_id == 8000 && questMng.GetQuestTalkIndex(_id) >= 40)
                    craftingCanvas.SetActive(true);

                quickSlot.SetActive(true);
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
    }

    public void GameSave()
    {
        // �÷��̾� ��ġ
        PlayerPrefs.SetFloat("Player X", player.transform.position.x);
        PlayerPrefs.SetFloat("Player Y", player.transform.position.y);
        PlayerPrefs.SetFloat("Player Z", player.transform.position.z);

        // ����Ʈ ����
        PlayerPrefs.SetInt("Quest ID", questMng.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questMng.GetquestActionIndex);

        //PlayerPrefs.SetInt("Year", timeMng.timestamp.year);
        //PlayerPrefs.SetInt("Season", (int)timeMng.timestamp.season);
        //PlayerPrefs.SetInt("Day", timeMng.timestamp.day);
        PlayerPrefs.SetInt("Hour", timeMng.timestamp.hour);
        PlayerPrefs.SetInt("Min", timeMng.timestamp.minute);

        //�κ��丮

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

        //int _year = PlayerPrefs.GetInt("Year");
        //int _day = PlayerPrefs.GetInt("Day");
        int _hour = PlayerPrefs.GetInt("Hour");
        int _min = PlayerPrefs.GetInt("Min");
        //GameTimestamp.Season _season = (GameTimestamp.Season)PlayerPrefs.GetInt("Season");

        timeMng.timestamp = new GameTimestamp(_hour, _min);

        player.transform.position = new Vector3(x, y, z);
        questMng.questId = questId;
        questMng.GetquestActionIndex = questActionindex;
        //questMng.ControllObject();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public static implicit operator GameManager(ObjPooling v)
    {
        throw new NotImplementedException();
    }
}
