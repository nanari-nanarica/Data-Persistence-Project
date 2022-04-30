using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{

    public static PersistenceManager Instance;
    public int bestScore;
    public string playerNameBestScore;
    public string playerName;

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
    }
}
