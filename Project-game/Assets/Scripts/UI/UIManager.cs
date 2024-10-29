using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameWonScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip gameWonSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    public void GameOver()
    {
        playerObject.SetActive(false);
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }
    public void GameWon()
    {
        //playerObject.SetActive(false);
        gameWonScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameWonSound);
    }
}
