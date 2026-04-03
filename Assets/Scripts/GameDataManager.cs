using UnityEngine;
using System.IO;


public class GameDataManager
{
    public bool SaveGameData(PlayerData playerdata, string filename)
    {
        string data = JsonUtility.ToJson(playerdata);
        string path = Application.dataPath + "/" + filename;
        File.WriteAllText(path, data);
        return true;
    }

    public PlayerData LoadGameData(string filename)
    {
        PlayerData playerdata = new PlayerData();
        string path = Application.dataPath + "/" + filename;

        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            playerdata = JsonUtility.FromJson<PlayerData>(data);
        }
        else
        {
            SaveGameData(playerdata, filename);
        }
        return playerdata;
    }
}
