using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningManager : MonoBehaviour
{
    [SerializeField] private GameObject anyText;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Image menu;
    [SerializeField] private Text[] texts;
    float fadeTime = 1.5f;

    private void Update()
    {
        if (Input.anyKeyDown && anyText.activeSelf)
        {
            StartCoroutine(FadeColor());
            foreach(Button button in buttons)
                button.enabled = true;
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

    IEnumerator FadeColor()
    {
        float curruntTime = 0;
        float percent = 0;
        
        while(percent < 1)
        {
            curruntTime += 0.003f;
            percent = curruntTime / fadeTime;

            Color menuColor = menu.color;
            foreach(Text text in texts)
            {
                Color textColor = text.color;
                textColor.a = Mathf.Lerp(0, 1, percent);
                text.color = textColor;
            }
            menuColor.a = Mathf.Lerp(0, 1, percent);
            menu.color = menuColor;

            yield return null;
        }
    }
}
