using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _monstersKilled;
    public bool Level1;
    public void RestartLevel()
    {
        SceneManager.LoadScene("LoopHeroLvl1_Map");
    }

    public void CheckLevel1()
    {
        if (_monstersKilled >= 3)
        {
            Level1 = true;
        }
    }
}
