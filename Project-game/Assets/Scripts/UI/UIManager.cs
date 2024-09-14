using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip gameWonSound;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    public void GameOver()
    {

        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
        

    }
    public void GameWon()
    {

        //gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameWonSound);


    }
}
