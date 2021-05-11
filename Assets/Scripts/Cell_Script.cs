using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Script : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject circle;
    [SerializeField] Text pointsText;
    [SerializeField] GameObject center;

    public bool getPoints = false;
    public bool setPoints = false;

    public bool getPointsOther = false;
    public bool setPointsOther = false;

    public int points;

    void Start()
    {
        pointsText.text = $"{points}";
        if (tag == "other_cell") center.GetComponent<Image>().color = Color.red;
        if (tag == "one_cell") center.GetComponent<Image>().color = Color.grey;
        if (tag == "cell") center.GetComponent<Image>().color = Color.cyan;
    }

    public void UpdatePoints()
    {
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

        if (setPointsOther == true)
        {
            points /= 2;
            circle.SetActive(false);
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

    public void PointsTransfer()
    {
        if (setPoints == false)
            circle.SetActive(true);
        else
            circle.SetActive(false);
        setPoints = !setPoints;
    }
}
