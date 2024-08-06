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
        ScoreNum = 0;
        PlayerScoreText.text = "Score: " + ScoreNum;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            ScoreNum = ScoreNum + 100;
            Debug.Log("coin");
            Debug.Log(ScoreNum);
            Destroy(collision.gameObject);
            PlayerScoreText.text = "Score: " + ScoreNum;
        }
    }

}
