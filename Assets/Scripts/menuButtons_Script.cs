using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons_Script : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    public void BackGame()
    {
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene($"{SceneManager.GetActiveScene().name}");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
