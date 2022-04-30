using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text textBestScoreAndPlayerName;
    
    private void Start() {
        if (PersistenceManager.Instance != null)
        {
        textBestScoreAndPlayerName.text =
             "Best Score: " + PersistenceManager.Instance.playerNameBestScore + ": " + PersistenceManager.Instance.bestScore;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
