using UnityEngine;

public class StartingZone : MonoBehaviour
{
    [SerializeField] private QuestManager _quesManager;
    [SerializeField] private LabyrinthManager _labyrinthManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _quesManager._isQuestFinished)
        {
            _labyrinthManager.EndRunInLabyrinth(false);
        }
    }
}
