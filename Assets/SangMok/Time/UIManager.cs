using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, ITimeTracker
{
    public static UIManager Instance { get; private set; }

    //[Header("Status Bar")]
    ////상태 표시줄의 도구 장착 슬롯 변수
    //public Image toolEquipSlot;

    //시간 UI 변수
    public Text timeText;
    public Text dateText;
    
    //[Header("Inventory System")]
    ////인벤토리 패널 변수
    //public GameObject inventoryPanel;
    ////인벤토리 패널의 도구 장착 슬롯 UI 변수
    //public HandInventorySlot toolHandSlot;
    ////도구 슬롯 UI 변수
    //public InventorySlot[] toolSlots;
    ////인벤토리 패널의 아이템 장착 슬롯 UI 변수
    //public HandInventorySlot itemHandSlot;
    ////아이템 슬롯 UI 변수
    //public InventorySlot[] itemSlots;

    ////항목 정보 상자 변
    //public Text itemNameText;
    //public Text itemDescriptionText;

    private void Awake()
    {
        //인스턴스가 두 개 이상인 경우 추가 인스턴스를 삭제합니다.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //정적 인스턴스를 이 인스턴스로 설정
            Instance = this;
        }
    }

    private void Start()
    {
        //RenderInventory();
        //AssignSlotIndexes();
        
        //개체 목록에 UIManager를 추가합니다. TimeManager는 시간이 업데이트될 때 알려줍니다.
        TimeManager.Instance.RegisterTracker(this);
    }

    //슬롯 UI 요소를 반복하고 참조 슬롯 인덱스를 할당합니다.
    //public void AssignSlotIndexes()
    //{
    //    for (int i = 0; i < toolSlots.Length; i++)
    //    {
    //        toolSlots[i].AssignIndex(i);
    //        itemSlots[i].AssignIndex(i);
    //    }
    //}

    ////플레이어의 인벤토리를 반영하도록 인벤토리 화면을 렌더링합니다.
    //public void RenderInventory()
    //{
    //    //인벤토리 관리자에서 인벤토리 도구 슬롯 가져오기
    //    ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;
    //    //인벤토리 관리자에서 인벤토리 아이/ 슬롯 가져오기
    //    ItemData[] inventoryItemSlots = InventoryManager.Instance.items;


    //    //도구 섹션 렌더링
    //    RenderInventoryPanel(inventoryToolSlots, toolSlots);
    //    //아이템 섹션 렌더링
    //    RenderInventoryPanel(inventoryItemSlots, itemSlots);
    //    //장착된 슬롯 렌더링
    //    toolHandSlot.Display(InventoryManager.Instance.equippedTool);
    //    itemHandSlot.Display(InventoryManager.Instance.equippedItem);
    //    //inventoryManager에서 도구 장비 가져오기
    //    ItemData equippedTool = InventoryManager.Instance.equippedTool;


    //    //표시할 항목이 있는지 확인
    //    if (equippedTool != null)
    //    {
    //        toolEquipSlot.sprite = equippedTool.thumbnail;

    //        toolEquipSlot.gameObject.SetActive(true);

    //        return;
    //    }

    //    toolEquipSlot.gameObject.SetActive(false);
    //}

    ////섹션의 슬롯을 반복하고 UI에 표시
    //void RenderInventoryPanel(ItemData[] _slots, InventorySlot[] _uiSlots)
    //{
    //    for (int i = 0; i < _uiSlots.Length; i++)
    //    {
    //        //toolSlots[i].Display(inventoryToolSlots[i]);
    //        _uiSlots[i].Display(_slots[i]);
    //    }
    //}

    //public void ToggleInventoryPanel()
    //{
    //    //패널이 숨겨져 있으면 표시하고 그 반대의 경우도 마찬가지입니다.
    //    inventoryPanel.SetActive(!inventoryPanel.activeSelf);

    //    RenderInventory();
    //}

    ////항목 정보 상자에 항목 정보 표시
    //public void DisplayItemInfo(ItemData _data)
    //{
    //    //데이터가 널이ㅑ
    //    if (_data == null)
    //    {
    //        itemNameText.text = "";
    //        itemDescriptionText.text = "";

    //        return;
    //    }

    //    itemNameText.text = _data.name;
    //    itemDescriptionText.text = _data.description;
    //}

    //시간 동안 UI를 처리하는 콜백
    public void ClockUpdate(GameTimestamp timestamp)
    {
        //시간 관리
        
        //시간과 분 얻기
        int hours = timestamp.hour;
        int minutes = timestamp.minute;
        
        //AM or PM
        string prefix = "AM ";
        
        //시간을 12시간제로 변환
        if (hours > 12)
        {
            //시간은 오후가 된다
            prefix = "PM ";
            hours -= 12;
        }

        //시간 텍스트 표시를 위해 그것을 전달하십시오.
        timeText.text = prefix + hours +":"+minutes.ToString("00");
        
        //날짜 처리
        int day = timestamp.day;
        string season = timestamp.season.ToString();
        string dayOfTheWeek = timestamp.GetDayOfTheWeek().ToString();
        
        //날짜 텍스트 표시 형식
        dateText.text = season + " " + day + " (" + dayOfTheWeek + " )";
        

    }
}
