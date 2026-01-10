using UnityEditor;
using UnityEngine;

public class DialogueComponent : MonoBehaviour, IActivable
{
    [SerializeField] private DialogueDatas _dialogueDatas;
    [SerializeField] private UIDialogueController _dialogueController;

    private DialogueRow _currentDialogueRow;
    private int _currentRowIndex;

    public void CellAction(Pawn playerPawn)
    {
        _currentDialogueRow = GetDialogueRow();
        _dialogueController.StartDialogue(this);
    }

    public DialogueRow GetDialogueRow() 
    {  
        return _dialogueDatas._rows[_currentRowIndex]; 
    }

    public int GetRowIndex()
    {
        return _currentRowIndex;
    }

    public string GetDialogueLongFromCurrentRow()
    {
        return _currentDialogueRow._dialogueLong;
    }

    public string GetCharacterNameFromCurrentRow()
    {
        return _currentDialogueRow._characterName;
    }

    public int GetNextRowNumberFromCurrentRow()
    {
        return _currentDialogueRow._nextRowNumber;
    }

    public void ReadNextRow()
    {
        _currentRowIndex = GetNextRowNumberFromCurrentRow();
        _currentDialogueRow = _dialogueDatas._rows[_currentRowIndex];   
    }

    public void ReadNextRowByCondition()
    {
        _currentRowIndex = _currentDialogueRow._nextRowByCondition;
        _currentDialogueRow = _dialogueDatas._rows[_currentRowIndex];
    }

    public bool IsDialogueFinished()
    {
        return _currentDialogueRow._isDialogueFinished;
    }

    public void ResetDialogue() 
    { 
        _currentDialogueRow = _dialogueDatas._rows[0];
    }

    private void Update()
    {
        Debug.Log(_currentRowIndex);
    }
}
