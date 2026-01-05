using UnityEngine;

[System.Serializable]
public struct DialogueRow
{
    public string _characterName;
    public string _dialogueLong;
    public int _nextRowNumber;
}

[CreateAssetMenu(fileName = "DialogueDatas", menuName = "Scriptable Objects/DialogueDatas")]
public class DialogueDatas : ScriptableObject
{
    public DialogueRow[] _rows;
}
