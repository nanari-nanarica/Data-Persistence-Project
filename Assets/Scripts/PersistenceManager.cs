using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{

    public static PersistenceManager Instance;
    public int bestScore;
    public string playerNameBestScore;
    public string playerName;
    
    public string savefileName = "savefile.json";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        bestScore = 0;
        playerNameBestScore = "Someone";

        LoadScoreAndName();
        Debug.Log(bestScore + "   " + playerNameBestScore);
    }
    
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string playerNameBestScore;
    }
    
    public void SaveScoreAndName()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.playerNameBestScore = playerNameBestScore;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/" + savefileName, json);
    }
    
    public void LoadScoreAndName()
    {
        string path = Application.persistentDataPath + "/" + savefileName;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            playerNameBestScore = data.playerNameBestScore;
        }
    }
}
