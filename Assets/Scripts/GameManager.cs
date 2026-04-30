using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerDatas _playerDatas;

    [SerializeField] private Pawn _playerPawnRef;

    [SerializeField] private UIPlayerDatasController _playerHUDRef;
    //private PlayerData _playerData;
    private GameDataManager _gameDataManager;
    private int levelNumber = 1;

    private void Start()
    {
        _playerDatas = ScriptableObject.CreateInstance<PlayerDatas>();

        _gameDataManager = new GameDataManager();
        /*_playerDatas._data._health = 20;
        _playerDatas._data._cellNumber = 0;
        _playerDatas._data._attack = 3;
        _playerDatas._data._money = 100;
        levelNumber = 2;

        SaveGame();*/
        LoadGame();

        _playerPawnRef.LateStart(_playerDatas);
        _playerHUDRef.LateStart(_playerDatas);
    }

    public void RestartLevel()
    {
        _playerDatas._data._health = 20;
        _playerDatas._data._cellNumber = 0;
        SaveGame();
        LoadGame();
        SceneManager.LoadScene("LoopHeroLvl" + levelNumber + "_Map");
        
    }

    public void NextLevel()
    {
        _playerDatas._data._cellNumber = 0;
        levelNumber++;
        Mathf.Clamp(levelNumber, 1, 3);
        SaveGame();
        LoadGame();
        SceneManager.LoadScene("LoopHeroLvl" + levelNumber + "_Map");

    }

    public void SaveGame()
    {
        _gameDataManager.SaveGameData(_playerDatas._data, "gameSaveFile.txt");
    }

    public void LoadGame()
    {
        _playerDatas._data = _gameDataManager.LoadGameData("gameSaveFile.txt");
    }

    private void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().ToString());
    }

    private void OnDestroy()
    {
        SaveGame();
    }
}
