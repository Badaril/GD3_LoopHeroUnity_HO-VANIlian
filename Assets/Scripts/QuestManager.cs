using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool _isQuestFinished;

    private int _monstersKilled;

    public void UpdateQuestState()
    {
        _monstersKilled += 1;
        if (_monstersKilled >= 3)
        {
            _isQuestFinished = true;
        }
    }
}
