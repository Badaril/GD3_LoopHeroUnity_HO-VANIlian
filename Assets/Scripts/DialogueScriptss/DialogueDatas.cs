using UnityEngine;

[System.Serializable]
public struct DialogueRow
{
    public string _characterName;
    public string _dialogueLong;
    public int _nextRowNumber;
    public int _nextRowByCondition;
    public bool _isDialogueFinished;
}

[CreateAssetMenu(fileName = "DialogueDatas", menuName = "Scriptable Objects/DialogueDatas")]
public class DialogueDatas : ScriptableObject
{
    public DialogueRow[] _rows;
}
