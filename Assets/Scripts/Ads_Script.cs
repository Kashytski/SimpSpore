using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads_Script : MonoBehaviour
{
    [SerializeField] Text winText;
    int i = 1;

    void Start()
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize("4130595",true);
    }
    void Update()
    {
        if (winText.text != "" && i == 1)
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                i = 0;
            }
    }
}
