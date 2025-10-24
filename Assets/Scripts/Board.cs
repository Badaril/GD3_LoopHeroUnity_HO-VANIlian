using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell[] _cellsTab;

    public Cell GetCellByNumber(int number)
    {  
        return _cellsTab[number]; 
    }

    public int GetNextCellToMove(int cellNumber) 
    {  
        return cellNumber % _cellsTab.Length; 
    } 
}
