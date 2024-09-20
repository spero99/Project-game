using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 5;
    [SerializeField] string filename;

    private void Start()
    {
        LoadHighscores();
    }
    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);

        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
    }
    private void SaveHighscores()
    {
        FileHandler.SaveToJSON<HighscoreElement>(highscoreList, filename);
    }

    public void AddHighScoreIfPossible(HighscoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i>= highscoreList.Count || element.points > highscoreList[i].points)
            {
                // add new highscore
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }
                
                SaveHighscores();  

                break;
            }
        }

    }
}