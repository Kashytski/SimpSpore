using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads_Script : MonoBehaviour
{
    [SerializeField] Text winText;


    void Start()
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize("4130595",false);
    }
    void Update()
    {
        if (winText.text != "")
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                Invoke("StopAds",5f);
            }
    }

    void StopAds()
    {
        winText.text = "Don't stop, keep move";
    }
}
