using UnityEngine;

public class LabyrinthManager : MonoBehaviour, IActivable
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _labyrinthCamera;
    [SerializeField] private GameObject _movingPawnPlayer;
    [SerializeField] private GameObject _ringRef;
    [SerializeField] private GameObject _startingZone;

    public void CellAction(Pawn playerPawn)
    {
        if (!_questManager._isQuestFinished)
        {
            _playerCamera.gameObject.SetActive(false);
            _labyrinthCamera.gameObject.SetActive(true);
            _movingPawnPlayer.SetActive(true);
        }
    }

    public void EndRunInLabyrinth(bool isKilled)
    {
        if (isKilled)
        {
            _questManager._isQuestFinished = false;
            _ringRef.SetActive(true);
        }
        _playerCamera.gameObject.SetActive(true);
        _labyrinthCamera.gameObject.SetActive(false);

        _movingPawnPlayer.SetActive(false);
        _movingPawnPlayer.transform.position = _startingZone.transform.position;
    }
}
