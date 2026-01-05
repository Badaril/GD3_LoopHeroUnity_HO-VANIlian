using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class UIDialogueController : MonoBehaviour
{
    private DialogueComponent _dialogueComponent;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _characterName;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private GameObject[] _diceButtons;


    public void StartDialogue(DialogueComponent dialogueComponent)
    {
        _dialogueComponent = dialogueComponent;
        UpdateText();
        _dialoguePanel.SetActive(true);
        SetAllButtons(false);
    }

    public void UpdateText()
    {
        _characterName.text = _dialogueComponent.GetCharacterNameFromCurrentRow();
        _dialogueText.text = _dialogueComponent.GetDialogueLongFromCurrentRow();
    }

    public void UpdateDialogue()
    {
        if (!(_dialogueComponent.IsDialogueFinished()))
        {
            _dialogueComponent.ReadNextRow();
            UpdateText();
        }
        else
        { 
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        _dialoguePanel.SetActive(false);
        SetAllButtons(true);
        _dialogueComponent.ResetDialogue();
    }

    private void SetAllButtons(bool active)
    {
        for (int i = 0; i < _diceButtons.Length; i++)
        {
            _diceButtons[i].gameObject.SetActive(active);
        }
    }
}
