using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class UIDialogueController : MonoBehaviour
{
    private DialogueComponent _dialogueComponent;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _characterName;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private GameObject _diceBox;


    public void StartDialogue(DialogueComponent dialogueComponent)
    {
        _dialogueComponent = dialogueComponent;
        UpdateText();
        _dialoguePanel.SetActive(true);
        _diceBox.gameObject.SetActive(false);
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
        _diceBox.gameObject.SetActive(true);
        _dialogueComponent.ResetDialogue();
    }
}
