using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField field;


    public TMP_Text textBestScoreAndPlayerName;

    private void Start()
    {
        if (PersistenceManager.Instance)
        {
            textBestScoreAndPlayerName.text =
                PersistenceManager.Instance.playerNameBestScore + " Got Best Score: " + PersistenceManager.Instance.bestScore;
        }
    }

    public void StartNew()
    {
        GetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


    public void GoRanking()
    {
        SceneManager.LoadScene(2);
    }
    

    public void GetPlayerName()
    {
        PersistenceManager.Instance.playerName = field.text;

#if UNITY_EDITOR
//        Debug.Log(PersistenceManager.Instance.playerName);
#endif
    }
}
