using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;
    public Slot dragSlot;

    [SerializeField]
    private Image imageItem;

    void Start()
    {
        instance = this;
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;//각각 스프라이트 넣어주기
        SetColor(1);
    }

    public void SetColor(float _alpha)//흰색의 배경을 평소에는 감춰두다가 드래그 할 때 보여주기
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
