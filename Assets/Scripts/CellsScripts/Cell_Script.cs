using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Script : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject circle;
    [SerializeField] Text pointsText;
    [SerializeField] GameObject center;

    public int points;

    public bool getPoints = false;
    public bool setPoints = false;

    public bool getPointsOther = false;
    public bool setPointsOther = false;

    void Start()
    {
        //????????? ???????? ? ????????? points
        pointsText.text = $"{points}";

        if (points == 0)
        {
            tag = "one_cell";
            center.GetComponent<Image>().color = Color.grey;
        }

        if (tag == "other_cell") center.GetComponent<Image>().color = Color.red;
        if (tag == "cell") center.GetComponent<Image>().color = Color.cyan;
    }

    public void UpdatePoints()
    {
        //?????? points ????? ????????, ??????????, ???? ?????
        //??? ????? ??????
        if (setPoints == true)
        {
            points /= 2;
            circle.SetActive(false);
            setPoints = false;
        }
        else if (getPoints == true)
        {
            getPoints = false;
        }

        //??? ????? ??????
        if (setPointsOther == true)
        {
            points /= 2;
            setPointsOther = false;
        }
        else if (getPointsOther == true)
        {
            getPointsOther = false;
        }

        if (points == 0)
        {
            center.GetComponent<Image>().color = Color.grey;
            tag = "one_cell";
        }

        pointsText.text = $"{points}";
    }

    //????? ???? ? ?????????? ??????-??????????, ???? ?????
    public void UpdateTagMy()
    {
        if (tag != "other_cell")
        {
            center.GetComponent<Image>().color = Color.cyan;
            tag = "cell";
        }
        else
        {
            if (points < 0)
            {
                center.GetComponent<Image>().color = Color.cyan;
                tag = "cell";
                points = -points;
            }
        }
    }

    //????? ???? ? ?????????? ??????-??????????, ???? ?????
    public void UpdateTagOther()
    {
        if (tag != "cell")
        {
            center.GetComponent<Image>().color = Color.red;
            tag = "other_cell";
        }
        else
        {
            if (points < 0)
            {
                center.GetComponent<Image>().color = Color.red;
                tag = "other_cell";
                points = -points;
            }
        }
    }

    //?????????? ?????????
    public void PointsTransfer()
    {
        circle.SetActive(true);
        setPoints = true;
    }
}
