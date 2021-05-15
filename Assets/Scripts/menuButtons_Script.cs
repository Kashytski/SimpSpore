using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MenuButtons_Script : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Text winText;

    public void BackGame()
    {
        //������� ������/���������/����������
        switch (winText.text)
        {
            case "Cyan Wins":

                //������� �������� �� ���� �������
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
                break;

            case "Red Wins":
                RestartGame();
                break;

            case "":
                StartCoroutine(HideMenu());
                break;
        }
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
        //���� �������� � ���������
        yield return new WaitForSeconds(0.25f);
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }
}
