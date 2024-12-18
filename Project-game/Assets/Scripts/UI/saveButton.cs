using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class saveButton : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInput;
    
    public  void onClickSave()
    {
        string name = nameInput.GetComponent<TMP_InputField>().text;
        int newScore = PlayerPrefs.GetInt("HighScore");
        highscoreTable.AddHighscoreEntry(newScore, name);
        PlayerPrefs.SetInt("HighScore", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
