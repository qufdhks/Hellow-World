using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningManager : MonoBehaviour
{
    [SerializeField] private GameObject anyText;
    [SerializeField] private GameObject menu;

    private void Update()
    {
        if (Input.anyKeyDown && anyText.activeSelf)
        {
            menu.SetActive(true);
            anyText.SetActive(false);
        }
    }

    public void ChangeColor(Text text)
    {
        StartCoroutine(Color(text));
    }

    IEnumerator Color(Text _text)
    {
        string text = _text.text;
        _text.text = "<color=black>" + _text.text + "</color>";
        yield return new WaitForSeconds(0.2f);
        _text.text = text;
    }
}
