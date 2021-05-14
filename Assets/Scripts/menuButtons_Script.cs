using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class menuButtons_Script : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Text winText;

    public void BackGame()
    {
        //”словие перехода на след уровень
        if (winText.text == "Cyan Wins")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level_1":
                    SceneManager.LoadScene("Level_2");
                    break;
                case "Level_2":
                    SceneManager.LoadScene("Level_3");
                    break;
                case "Level_3":
                    SceneManager.LoadScene("Level_1");
                    break;
            }
        }
        else
            StartCoroutine(HideMenu());
    }

    public void RestartGame()
    {
        String sceneName = $"{SceneManager.GetActiveScene().name}";
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator HideMenu()
    {
        //ћеню пр€четс€ с задержкой
        yield return new WaitForSeconds(0.2f);
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }
}
