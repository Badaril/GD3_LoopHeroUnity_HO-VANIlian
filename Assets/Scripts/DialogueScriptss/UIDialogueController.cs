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

    [SerializeField] private QuestManager _questManager;
    [SerializeField] private UIPlayerDatasController _uIPlayerDatasController;

    public void StartDialogue(DialogueComponent dialogueComponent)
    {
        _dialogueComponent = dialogueComponent;
        if (_questManager._isQuestFinished)
        {
            _dialogueComponent.ReadNextRowByCondition();
        }
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
            if (_questManager._isQuestFinished)
            {
                _dialogueComponent.ReadNextRowByCondition();
                UpdateText();
            }
            else
            {
                _dialogueComponent.ReadNextRow();
            }
        EndDialogue();
        }
    }

    public void EndDialogue()
    {
        _dialoguePanel.SetActive(false);
        _diceBox.gameObject.SetActive(true);
        if (_questManager._isQuestFinished)
        {
            _uIPlayerDatasController.DisplayNextLevelHUD();
        }
    }
}
