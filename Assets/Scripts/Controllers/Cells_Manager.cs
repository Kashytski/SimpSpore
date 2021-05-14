using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cells_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Text winText;

    GameObject[] Cells;
    GameObject[] OtherCells;
    GameObject[] OneCells;

    public List<GameObject> AllCells;


    void Start()
    {
        //Сбор всех клеток в один список
        Cells = GameObject.FindGameObjectsWithTag("cell");
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        OneCells = GameObject.FindGameObjectsWithTag("one_cell");


        for (int i = 0; i < Cells.Length; i++)
            AllCells.Add(Cells[i]);

        for (int i = 0; i < OtherCells.Length; i++)
            AllCells.Add(OtherCells[i]);

        for (int i = 0; i < OneCells.Length; i++)
            AllCells.Add(OneCells[i]);
    }

    void Update()
    {
        //Проверка текущей принадлежности каждой клетки
        Cells = GameObject.FindGameObjectsWithTag("cell");
        OtherCells = GameObject.FindGameObjectsWithTag("other_cell");
        OneCells = GameObject.FindGameObjectsWithTag("one_cell");

        if (menuPanel.activeInHierarchy == false)
        {
            if (OtherCells.Length == 0)
            {
                menuPanel.SetActive(true);
                winText.text = "Cyan Wins";
                winText.color = Color.cyan;
            }
        }
    }

    public void PointsTransfer()
    {
        //Проверка наличия клеток-передатчиков
        foreach (var q in AllCells)
            if (q.GetComponent<Cell_Script>().setPoints == true)
            {
                //Проверка наличия клеток-получателей
                foreach (var i in AllCells)
                    if (i.GetComponent<Cell_Script>().getPoints == true)
                    {
                        //Передача частиц от Клеток-передатчиков Клетке-получателю и снятие выделения
                        foreach (var j in AllCells)
                            if (j.GetComponent<Cell_Script>().setPoints == true)
                            {
                                if (i.tag == "one_cell")
                                {
                                    j.GetComponent<Cell_Script>().UpdatePoints();
                                    i.GetComponent<Cell_Script>().points
                                    += j.GetComponent<Cell_Script>().points;
                                }

                                if (i.tag == "other_cell")
                                {
                                    j.GetComponent<Cell_Script>().UpdatePoints();
                                    i.GetComponent<Cell_Script>().points
                                    -= j.GetComponent<Cell_Script>().points;
                                }
                            }

                        i.GetComponent<Cell_Script>().UpdateTagMy();
                        i.GetComponent<Cell_Script>().UpdatePoints();
                        //Передача уже окончена
                        break;
                    }
                //Передача уже окончена
                break;
            }
    }
}