using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell[] _cellsTab;
    [SerializeField] private GameObject mazePath;
    [SerializeField] private Cell[] _mazePathTab;

    public Cell GetCellByNumber(int number)
    {  
        return _cellsTab[number]; 
    }

    public int GetNextCellToMove(int cellNumber) 
    {  
        return cellNumber % _cellsTab.Length; 
    }
    
    public void OpenMazePath()
    {
        int insertIndex = 5;          
        int removedCount = 18;          

        int newSize = _cellsTab.Length - removedCount + _mazePathTab.Length;
        var newCells = new Cell[newSize];

        for (int i = 0; i < newSize; i++)
        {
            if (i < insertIndex)
            {
                newCells[i] = _cellsTab[i];
            }
            else if (i < insertIndex + _mazePathTab.Length)
            {
                newCells[i] = _mazePathTab[i - insertIndex];
            }
            else
            {
                newCells[i] = _cellsTab[i - _mazePathTab.Length + removedCount];
            }
        }

        _cellsTab = newCells;
        mazePath.SetActive(true);
    }
}
