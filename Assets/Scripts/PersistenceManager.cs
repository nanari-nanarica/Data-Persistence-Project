using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class PersistenceManager : MonoBehaviour
{

    public static PersistenceManager Instance;
    public int bestScore;
    public string playerNameBestScore;
    public string playerName;
    public ListSaveData listData;
    
    public int maxLine = 6;
    public float paddleSpeed = 2.0f;
    public float accel = 0.01f;

    public string savefileName = "savefile.json";
    public string savefileName2 = "savefile2.json";
    public int maxBestScore = 3;

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
        listData = new ListSaveData();
        listData.data = new List<SaveData>();
        


        // LoadScoreAndName();
        LoadScoreAndName2();
    }

    [System.Serializable]
    public class SaveData
    {
        public int bestScore;
        public string playerNameBestScore;
    }


    [System.Serializable]
    public class ListSaveData
    {
        public List<SaveData> data;
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

    public void SaveScoreAndName2()
    {
        SaveData data = new SaveData();

        data.bestScore = bestScore;
        data.playerNameBestScore = playerNameBestScore;

        if (listData.data != null && listData.data.Count >= maxBestScore)
        {
            listData.data.RemoveAt(0);
        }
        listData.data.Add(data);
        Debug.Log(listData.data.Count);
        string json = JsonUtility.ToJson(listData);

        File.WriteAllText(Application.persistentDataPath + "/" + savefileName2, json);
    }

    public void LoadScoreAndName2()
    {
        string path = Application.persistentDataPath + "/" + savefileName2;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
             
            listData = JsonUtility.FromJson<ListSaveData>(json);

            bestScore = listData.data.Last().bestScore;
            playerNameBestScore = listData.data.Last().playerNameBestScore;
        }
    }
}
