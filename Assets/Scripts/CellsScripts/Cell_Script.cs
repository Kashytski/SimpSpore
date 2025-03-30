using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Script : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject circle;
    [SerializeField] Text pointsText;
    [SerializeField] Image center;

    public int points;

    public bool getPoints = false;
    public bool setPoints = false;

    public bool getPointsOther = false;
    public bool setPointsOther = false;

    public void OwnStart()
    {
        pointsText.text = $"{points}";

        if (points == 0)
        {
            tag = "one_cell";
            center.color = Color.grey;
        }

        switch (tag)
        {
            case "other_cell":
                center.color = Color.red;
                break;

            case "cell":
                center.color = Color.cyan;
                break;
        }
    }

    public void UpdatePoints()
    {
        if (setPoints)
        {
            points /= 2;
            circle.SetActive(false);
            setPoints = false;
        }
        else if (getPoints)
        {
            getPoints = false;
        }

        if (setPointsOther)
        {
            points /= 2;
            setPointsOther = false;
        }
        else if (getPointsOther)
        {
            getPointsOther = false;
        }

        if (points == 0)
        {
            center.color = Color.grey;
            tag = "one_cell";
        }

        pointsText.text = $"{points}";
    }

    public void UpdateTagMy()
    {
        if (tag != "other_cell")
        {
            center.color = Color.cyan;
            tag = "cell";
            Cell_Controller.Instance.Replace(this);
        }
        else
        {
            if (points < 0)
            {
                center.color = Color.cyan;
                tag = "cell";
                Cell_Controller.Instance.Replace(this);
                points = -points;
            }
        }
    }

    public void UpdateTagOther()
    {
        if (tag != "cell")
        {
            center.color = Color.red;
            tag = "other_cell";
            Cell_Controller.Instance.Replace(this);
        }
        else
        {
            if (points < 0)
            {
                center.color = Color.red;
                tag = "other_cell";
                points = -points;
                Cell_Controller.Instance.Replace(this);
            }
        }
    }

    public void PointsTransfer()
    {
        circle.SetActive(true);
        setPoints = true;
    }
}
