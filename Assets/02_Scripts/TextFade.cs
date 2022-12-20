using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TextFade : MonoBehaviour
{
    [SerializeField] private Text text;

    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            text.text = "";
            yield return new WaitForSeconds(0.5f);
            text.text = "화면을 터치해주세요...";
        }
    }
}
