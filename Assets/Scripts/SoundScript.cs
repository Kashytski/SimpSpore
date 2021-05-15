using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;

    void Update()
    {
        if (menuPanel.activeInHierarchy == true)
            GetComponent<AudioSource>().Pause();
        else
            GetComponent<AudioSource>().UnPause();
    } 
}
