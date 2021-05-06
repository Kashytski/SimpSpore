using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Incr : MonoBehaviour
{
    [SerializeField]Text points;
    [SerializeField]GameObject center;
    public int bound;
    float time = 0;

    void Update()
    {
      if (center.GetComponent<Image>().color != Color.grey)
        {
            time++;
            if (time/120 == 2)
            {
                time = 0;
                points.text = $"{int.Parse(points.text)+1}";
                if (int.Parse(points.text) > bound) points.text = $"{bound}";
                GetComponent<Cell_Script>().points = int.Parse(points.text);
            }
        }
    }
}
