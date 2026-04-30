using UnityEngine;

public struct GameDatasInfos
{
    public int _playerPosition;
    public bool _isInMiniGame;
    public int _miniGameNumber;
}

[CreateAssetMenu(fileName = "GameDatasStruct", menuName = "Scriptable Objects/GameDatasStruct")]
public class GameDatasStruct : ScriptableObject
{
    public GameDatasInfos _gameDatasInfos;
}
