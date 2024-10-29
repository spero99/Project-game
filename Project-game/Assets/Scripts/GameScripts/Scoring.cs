using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public Text PlayerScoreText;
    public int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = PlayerPrefs.GetInt("HighScore");
        PlayerScoreText.text = "Score: " + ScoreNum;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            ScoreNum = PlayerPrefs.GetInt("HighScore");
            ScoreNum = ScoreNum + 100;
            PlayerPrefs.SetInt("HighScore", ScoreNum);
            Destroy(collision.gameObject);
            PlayerScoreText.text = "Score: " + ScoreNum;
        }
    }


    //OBSOLETE
    private void SaveHighscore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
    //OBSOLETE
    public void SetHighscoreIfGreater(int score)
    {
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            SaveHighscore(score);
        }
    }
    //OBSOLETE
    private void setLatestHighscore()
    {
        //
    }

}
