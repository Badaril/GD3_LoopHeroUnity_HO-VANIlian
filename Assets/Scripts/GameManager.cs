using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerDatas _playerDatas;
    public void RestartLevel()
    {
        _playerDatas._health = 20;
        _playerDatas._cellNumber = 0;
        SceneManager.LoadScene("LoopHeroLvl1_Map");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("LoopHeroLvl2_Map");

    }
}
