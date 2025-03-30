using UnityEngine;

public class OtherCells_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] int interval;
    private MenuButtons menuPanel => Cell_Controller.Instance.MenuPanel;
    private Cell_Script[] otherCellsObj => Cell_Controller.Instance.otherCells;
    private Cell_Script[] cellsObj => Cell_Controller.Instance.cells;
    private Cell_Script[] allCellsObj => Cell_Controller.Instance.allCells;

    float time = 0;

    void Update()
    {
        //Debug.LogWarning(otherCellsObj.Length);
        //Debug.LogWarning(cellsObj.Length);

        if (!menuPanel.gameObject.activeInHierarchy)
        {
            if (otherCellsObj.Length > 0)
                if (cellsObj.Length > 0)
                {
                    time += Time.deltaTime;
                    if (time > interval)
                    {
                        time = 0;
                        PointsTransfer();
                    }
                }
                else
                {
                    menuPanel.gameObject.SetActive(true);
                    menuPanel.RedWins();
                }
        }
    }

    public void PointsTransfer()
    {
        int RandomGet;

        for (int i = 0; i < 3; i++)
        {
            RandomGet = Random.Range(0, otherCellsObj.Length);
            otherCellsObj[RandomGet].setPointsOther = true;
        }

        RandomGet = 0;
        do
        {
            allCellsObj[RandomGet].getPointsOther = false;
            RandomGet = Random.Range(0, allCellsObj.Length);
            allCellsObj[RandomGet].getPointsOther = true;
        }
        while (allCellsObj[RandomGet].CompareTag("other_cell"));

        foreach (var j in allCellsObj)
            if (j.setPointsOther)
            {
                j.UpdatePoints();

                switch (allCellsObj[RandomGet].tag)
                {
                    case "one_cell":
                        allCellsObj[RandomGet].points += j.points;
                        break;

                    case "cell":
                        allCellsObj[RandomGet].points -= j.points;
                        break;
                }
            }

        allCellsObj[RandomGet].UpdateTagOther();
        allCellsObj[RandomGet].UpdatePoints();
    }
}