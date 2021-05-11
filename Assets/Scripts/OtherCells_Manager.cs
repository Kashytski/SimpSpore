using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCells_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject menuPanel;

    GameObject[] MyCells;
    GameObject[] OtherCells;
    GameObject[] OneCells;

    public List<GameObject> AllCells;

    int time = 0;

    void Start()
    {
        MyCells = GameObject.FindGameObjectsWithTag("cell");
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        OneCells = GameObject.FindGameObjectsWithTag("one_cell");


        for (int i = 0; i < MyCells.Length; i++)
            AllCells.Add(MyCells[i]);

        for (int i = 0; i < OtherCells.Length; i++)
            AllCells.Add(OtherCells[i]);

        for (int i = 0; i < OneCells.Length; i++)
            AllCells.Add(OneCells[i]);
    }

    void Update()
    {
        if (menuPanel.activeInHierarchy == false)
        {
            time++;
            if (time / 120 >= 4)
            {
                time = 0;
                PointsTransfer();
            }
        }
    }

    public void PointsTransfer()
    {
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        foreach (var q in OtherCells)
        {
            if (Random.RandomRange(0, 2) == 1)
                q.GetComponent<Cell_Script>().setPointsOther = true;
        }

        int RandomGet = Random.RandomRange(0, AllCells.Count);
        AllCells[RandomGet].GetComponent<Cell_Script>().getPointsOther = true;
                

        foreach (var q in AllCells)
            if (q.GetComponent<Cell_Script>().setPointsOther == true)
            {
                foreach (var i in AllCells)
                    if (i.GetComponent<Cell_Script>().getPointsOther == true)
                    {
                        foreach (var j in AllCells)

                            if (j.GetComponent<Cell_Script>().setPointsOther == true)
                            {
                                if (i.tag == "other_cell" || i.tag == "one_cell")
                                {
                                    j.GetComponent<Cell_Script>().UpdatePoints();
                                    i.GetComponent<Cell_Script>().points
                                    += j.GetComponent<Cell_Script>().points;
                                }

                                if (i.tag == "cell")
                                {
                                    j.GetComponent<Cell_Script>().UpdatePoints();
                                    i.GetComponent<Cell_Script>().points
                                    -= j.GetComponent<Cell_Script>().points;
                                }
                            }

                        i.GetComponent<Cell_Script>().UpdateTagOther();
                        i.GetComponent<Cell_Script>().UpdatePoints();
                        break;
                    }
            }
    }
}