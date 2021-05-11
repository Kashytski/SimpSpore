using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherCells_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Text winText;

    GameObject[] Cells;
    GameObject[] OtherCells;
    GameObject[] OneCells;

    public int speed;
    public List<GameObject> AllCells;

    int time = 0;

    void Start()
    {
        Cells = GameObject.FindGameObjectsWithTag("cell");
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        OneCells = GameObject.FindGameObjectsWithTag("one_cell");

        //Все клетки в одном листе
        for (int i = 0; i < Cells.Length; i++)
            AllCells.Add(Cells[i]);

        for (int i = 0; i < OtherCells.Length; i++)
            AllCells.Add(OtherCells[i]);

        for (int i = 0; i < OneCells.Length; i++)
            AllCells.Add(OneCells[i]);
    }

    void Update()
    {
        Cells = GameObject.FindGameObjectsWithTag("cell");
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        OneCells = GameObject.FindGameObjectsWithTag("one_cell");

        if (menuPanel.activeInHierarchy == false)
        {
            if (Cells.Length > 0 || OneCells.Length > 0)
            {
                time++;
                if (time / 120 == speed)
                {
                    time = 0;
                    PointsTransfer();
                }
            }
            else
            {
                menuPanel.SetActive(true);
                winText.text = "Red Wins";
                winText.color = Color.red;
            }
        }
    }

    public void PointsTransfer()
    {
        //Соперник выделяет клетки
        int RandomGet;

        for (int i = 0; i < 3; i++)
        {
            RandomGet = Random.Range(0, OtherCells.Length);
            OtherCells[RandomGet].GetComponent<Cell_Script>().setPointsOther = true;
        }

        //Соперник выбирает клетку для получения частиц
        RandomGet = 0;
        do
        {
            AllCells[RandomGet].GetComponent<Cell_Script>().getPointsOther = false;
            RandomGet = Random.Range(0, AllCells.Count);
            AllCells[RandomGet].GetComponent<Cell_Script>().getPointsOther = true;
        }
        while (AllCells[RandomGet].tag == "other_cell");

        //Проверка наличия выделенных клеток
        foreach (var j in AllCells)

            if (j.GetComponent<Cell_Script>().setPointsOther == true)
            {
                if (AllCells[RandomGet].tag == "other_cell" || AllCells[RandomGet].tag == "one_cell")
                {
                    j.GetComponent<Cell_Script>().UpdatePoints();
                    AllCells[RandomGet].GetComponent<Cell_Script>().points
                    += j.GetComponent<Cell_Script>().points;
                }

                if (AllCells[RandomGet].tag == "cell")
                {
                    j.GetComponent<Cell_Script>().UpdatePoints();
                    AllCells[RandomGet].GetComponent<Cell_Script>().points
                    -= j.GetComponent<Cell_Script>().points;
                }
            }

        AllCells[RandomGet].GetComponent<Cell_Script>().UpdateTagOther();
        AllCells[RandomGet].GetComponent<Cell_Script>().UpdatePoints();
    }
}