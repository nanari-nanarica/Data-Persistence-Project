using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RankUIHandler : MonoBehaviour
{

    public GameObject nameContainer;
    public GameObject scoreContainer;

    public Transform[] arrayNames;
    public Transform[] arrayScores;

    void Start()
    {
        arrayNames = Functions.GetChildren(nameContainer.transform);
        arrayScores = Functions.GetChildren(scoreContainer.transform);
        List<PersistenceManager.SaveData> listSave = PersistenceManager.Instance.listData.data;
        int max = PersistenceManager.Instance.maxBestScore;

        if (listSave.Count > 0)
        {

            for (int i = listSave.Count - 1; i >= 0; i--)
            {
                arrayNames[max - i].gameObject.GetComponent<TMP_Text>().text = listSave[i].playerNameBestScore;
                arrayScores[max - i].gameObject.GetComponent<TMP_Text>().text = listSave[i].bestScore.ToString();
            }
        }
    }

    public void BackToMenuRank()
    {
        SceneManager.LoadScene(0);
    }

}