using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject title;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panel.activeSelf)
        {
            panel.SetActive(false);
            title.SetActive(true);
        }
    }

    public void NewGameStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void ContinueGameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Manual()
    {
        panel.SetActive(true);
        title.SetActive(false);
    }
}
