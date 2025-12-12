using UnityEngine;

public class DialogueComponent : MonoBehaviour, IActivable
{
    [SerializeField] private DialogueDatas _dialogueDatas;
    [SerializeField] private UIDialogueController _dialogueController;
    private DialogueRow _currentDialogueRow;
    private int _currentRowIndex = 0;

    public void CellAction(Pawn playerPawn)
    {
        _currentDialogueRow = GetDialogueRow();
        _dialogueController.StartDialogue(this);
        
    }
    //public void CellUpdate(Pawn playerPawn)  {  }

    //public void CellDeactivate(Pawn playerPawn) { }

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
        _currentDialogueRow = _dialogueDatas._rows[GetNextRowNumberFromCurrentRow()];
    }

    public bool IsDialogueFinished()
    {
        return GetNextRowNumberFromCurrentRow() < 0;
    }

    public void ResetDialogue() 
    { 
        _currentDialogueRow = _dialogueDatas._rows[0];
    }

    
}
