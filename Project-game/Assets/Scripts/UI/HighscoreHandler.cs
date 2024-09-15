using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 5;

    private void Start()
    {
        LoadHighscores();
    }
    private void LoadHighscores()
    {

    }
}