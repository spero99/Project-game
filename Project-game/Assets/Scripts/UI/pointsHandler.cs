using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pointsHandler : MonoBehaviour
{
    [SerializeField] InputField playerName;
    public int score;
    public Scoring scoreScript;
    public string playerNameStr;
    private string newHighscore;
    private string oldHighscore;


    public void SaveHighscore(string playerName)
    {
        //gets ze score from playeprefs
        score = PlayerPrefs.GetInt("HighScore");
        Debug.Log("your Score is " + score);
        //gets ze name from end/wonscreen
        playerNameStr = playerName;

        //if there are no highscores saved you add the first highscore 
        if (PlayerPrefs.GetString("playerHighScore") == "")
        {
            newHighscore = playerName + "*" + score.ToString() + "*";
            PlayerPrefs.SetString("playerHighScore", newHighscore);
        }
        //if there are highscore already registered you add one more 
        else
        {
            oldHighscore = PlayerPrefs.GetString("playerHighScore");
            newHighscore = oldHighscore + playerName + "*" + score.ToString() + "*";
        }

        SceneManager.LoadScene(0);

    }

    public void DisplayHighscores()
    {
        string allthescores = PlayerPrefs.GetString("playerHighScore");
        string[] splitstring = allthescores.Split('*');
        
        for (int i = 0; i <= splitstring.Length; i++)
        {

        }

        
        
    }
   
            



}

