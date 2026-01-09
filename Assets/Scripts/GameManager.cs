using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _monstersKilled;
    public void RestartLevel()
    {
        SceneManager.LoadScene("LoopHeroLvl1_Map");
    }
}
