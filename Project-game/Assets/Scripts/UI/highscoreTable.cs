using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class highscoreTable : MonoBehaviour
{   //https://www.youtube.com/watch?v=iAbaqGYdnyI
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
        string jsonString;
        jsonString = PlayerPrefs.GetString("highscoreTable");
        if (jsonString == "")
        {
            InitializeDefaultHighscores();
            jsonString = PlayerPrefs.GetString("highscoreTable");
        }
        else
        {   
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            
            //sort the list
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
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
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }

    }

    public void InitializeDefaultHighscores()
    {
        Debug.Log("init 1");
        highscoreEntryList = new List<HighscoreEntry>(){
            new HighscoreEntry { score = 290, name = "butcher" },
            new HighscoreEntry { score = 390, name = "rogXfactor" },
            new HighscoreEntry { score = 420, name = "petrakis" },
            new HighscoreEntry { score = 666, name = "psarilaos" },
            new HighscoreEntry { score = 999, name = "ricochette" },
            };
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);

        }
        Highscores highscorestmp = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscorestmp);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        //creates the rank for each position based on the position in the list 
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
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

    public static void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
    }

    [System.Serializable]
    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    //represents single highscore entry 
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
