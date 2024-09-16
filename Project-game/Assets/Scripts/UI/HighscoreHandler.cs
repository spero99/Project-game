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
    }
    private void SaveHighscores()
    {
        FileHandler.SaveToJSON<HighscoreElement>(highscoreList, filename);
    }
}