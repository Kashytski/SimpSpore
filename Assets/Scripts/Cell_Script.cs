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

        if (points == 0)
        {
            center.GetComponent<Image>().color = Color.grey;
            tag = "one_cell";
        }

        pointsText.text = $"{points}";
    }

    public void UpdateTag()
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

    public void PointsTransfer()
    {
        if (setPoints == false)
            circle.SetActive(true);
        else
            circle.SetActive(false);
        setPoints = !setPoints;
    }
}
