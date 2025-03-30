using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cell_Controller : MonoBehaviour
{
    public static Cell_Controller Instance;
    [SerializeField] MenuButtons menuPanel;
    public Cell_Script[] cells;
    public Cell_Script[] otherCells;
    public Cell_Script[] oneCells;
    public Cell_Script[] allCells;
    public MenuButtons MenuPanel => menuPanel;

    void Awake()
    {
        Instance = this;

        allCells = cells.Concat(otherCells).Concat(oneCells).ToArray();

        foreach (Cell_Script cellObj in allCells)
            cellObj.OwnStart();
    }

    public void Replace(Cell_Script cellObj)
    {
        RemoveCellFromAllArrays(cellObj);
        AddCellToArrayByTag(cellObj);
    }

    private void RemoveCellFromAllArrays(Cell_Script cell)
    {
        cells = cells.Where(c => c != cell).ToArray();
        oneCells = oneCells.Where(c => c != cell).ToArray();
        otherCells = otherCells.Where(c => c != cell).ToArray();
    }
    private void AddCellToArrayByTag(Cell_Script cell)
    {
        switch (cell.tag)
        {
            case "cell":
                cells = cells.Append(cell).ToArray();
                break;

            case "other_cell":
                otherCells = otherCells.Append(cell).ToArray();
                break;

            case "one_cell":
                oneCells = oneCells.Append(cell).ToArray();
                break;

            default:
                Debug.LogWarning($"Unknown tag '{cell.tag}' on cell '{cell.name}'");
                break;
        }
    }
}
