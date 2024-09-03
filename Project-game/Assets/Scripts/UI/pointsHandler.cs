using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsHandler : MonoBehaviour
{
    [SerializeField] InputField playerName;
    public int score;
    public Scoring scoreScript;

    public void SaveHighscore(string playerName)
    {
        score = scoreScript.ScoreNum;
        Debug.Log("your Score is " + score);
       

    }
}
