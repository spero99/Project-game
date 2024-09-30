using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class highscoreTable : MonoBehaviour
{   //https://www.youtube.com/watch?v=iAbaqGYdnyI
    /*1
    [SerializeField] Transform entryContainer;
    [SerializeField] Transform entryTemplate;
    [SerializeField] Transform posText;
    [SerializeField] Transform nameText;
    [SerializeField] Transform scoreText;
    */

    private Transform entryContainer;
    private Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    // Start is called before the first frame update
    void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        /*1
        entryTemplate.gameObject.SetActive(false);
        */


        /*
        highscoreEntryList = new List<HighscoreEntry>(){
            new HighscoreEntry { score = 52185, name = "vhhsdfhs" },
            new HighscoreEntry { score = 554821, name = "awgfv" },
            new HighscoreEntry { score = 44782, name = "sfffsdf" },
            new HighscoreEntry { score = 11445, name = "vwazsdfgwrg" },
            new HighscoreEntry { score = 4089, name = "cyydsw" },
        };
        */

        //AddHighscoreEntry(999999, "cmk");


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //sort the list 
        for(int i=0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j =  i+1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;    
                }
            }
        }

        //deletes the extra scores if there are more than 5 
        if (highscores.highscoreEntryList.Count > 5)
        {
            for (int h = highscores.highscoreEntryList.Count; h > 5; h--)
            {
                highscores.highscoreEntryList.RemoveAt(5);
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        /*
        Highscores highscores =new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */


    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank){
        default:
            rankString = rank + "th"; break;
        case 1: rankString = "1st"; break;
        case 2: rankString = "2nd"; break;
        case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
        transformList.Add(entryTransform);

    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Debug.Log(jsonString);
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        //Debug.Log(jsonString);

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    //represents single highscore entry 
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
    

}
