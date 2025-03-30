using UnityEngine;

public class Cells_Manager : MonoBehaviour, IInteractable
{
    private Cell_Script[] allCellsObj => Cell_Controller.Instance.allCells;
    private Cell_Script[] otherCellsObj => Cell_Controller.Instance.otherCells;
    private MenuButtons menuPanel => Cell_Controller.Instance.MenuPanel;

    void Update()
    {
        if (!menuPanel.gameObject.activeInHierarchy)
        {
            if (otherCellsObj.Length == 0)
            {
                menuPanel.gameObject.SetActive(true);
                menuPanel.CyanWins();
            }
        }
    }

    public void PointsTransfer()
    {
        foreach (var q in allCellsObj)
            if (q.setPoints)
            {
                foreach (var i in allCellsObj)
                    if (i.getPoints)
                    {
                        foreach (var j in allCellsObj)
                            if (j.setPoints)
                            {
                                j.UpdatePoints();

                                switch (i.tag)
                                {
                                    case "one_cell":
                                    case "cell":
                                        i.points += j.points;
                                        break;

                                    case "other_cell":
                                        i.points -= j.points;
                                        break;
                                }
                            }

                        i.UpdateTagMy();
                        i.UpdatePoints();
                        break;
                    }
                break;
            }
    }
}