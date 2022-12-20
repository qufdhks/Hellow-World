using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private Text talkText;
    [SerializeField] private GameObject scanObject;
    [SerializeField] private bool isAction;


    public void Action(GameObject scanObj)
    {
        if (isAction)
            isAction = false;
        else
        {
            isAction = true;
            scanObject = scanObj;
            talkText.text = scanObject.name;
        }
        talkPanel.SetActive(isAction);
    }
}
