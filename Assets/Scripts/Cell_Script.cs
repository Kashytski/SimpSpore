using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_Script : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject circle;
    [SerializeField] Text pointsText;

    public bool getPoints = false;
    public bool setPoints = false;
    public int points;

    void Start()
    {
        points = int.Parse(pointsText.text);
    }

    public void UpdatePoints()
    {
        if (getPoints == true)
        {
            getPoints = false;
        }
        else if (setPoints == true)
        {
            points /= 2;
            circle.SetActive(false);
            setPoints = false;
        }
        pointsText.text = $"{points}";
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
