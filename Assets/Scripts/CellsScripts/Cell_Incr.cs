using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Incr : MonoBehaviour
{
    [SerializeField] Text points;
    [SerializeField] Image center;
    private GameObject menuPanel => Cell_Controller.Instance.MenuPanel.gameObject;

    public int bound;
    float time = 0;

    void Update()
    {
        if (!menuPanel.activeInHierarchy)
        {
            if (center.color != Color.grey)
            {
                time += Time.deltaTime;
                if (time > 1)
                {
                    time = 0;
                    points.text = $"{int.Parse(points.text) + 1}";
                    if (int.Parse(points.text) > bound) points.text = $"{bound}";
                    GetComponent<Cell_Script>().points = int.Parse(points.text);
                }
            }
        }
    }
}
