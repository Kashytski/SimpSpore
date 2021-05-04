using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells_Manager : MonoBehaviour, IInteractable
{
    GameObject[] AllCells;
    
    void Start()
    {
        AllCells = GameObject.FindGameObjectsWithTag("cell");
    }

    public void PointsTransfer()
    {
        foreach (var i in AllCells)
            if (i.GetComponent<Cell_Script>().getPoints == true)
            {
                foreach (var j in AllCells)
                    if (j.GetComponent<Cell_Script>().setPoints == true)
                    {
                        j.GetComponent<Cell_Script>().UpdatePoints();
                        i.GetComponent<Cell_Script>().points
                            += j.GetComponent<Cell_Script>().points;
                    }

                i.GetComponent<Cell_Script>().UpdatePoints();
                break;
            }
    }
}
