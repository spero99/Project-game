using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public static List<int> leftLevels;
    public AudioMixer audioMixer;
    private void Start()
    {
              
    }
    public void PlayGame()
    {
        InitializeLeftLevels();
        int score = 0;
        PlayerPrefs.SetInt("HighScore", score);
        //obsolete loads the next scene in the build
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(GetNextLevelIndex());

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    public static int GetNextLevelIndex()
    {       
        //gets the next level from the levels available
        int nextLevelIndex = leftLevels[0];
        Debug.Log(nextLevelIndex);
        //removes the level selected from the available levels so we dont replay that level
        leftLevels.RemoveAt(0);
        return nextLevelIndex;
     }

    public static void InitializeLeftLevels()
    {
        //creates a list of indexes with the available maps/levels 
        leftLevels = new List<int> {  1, 2, 3, 4 };
        //randomize the indexes to create the roguelite mechanic 
        for( int i = 0; i<69; i++)
        {
            int tmp  = Random.Range(0, leftLevels.Count);
            int tmp2 = Random.Range(0, leftLevels.Count);
            int tempLvl = leftLevels[tmp];
            leftLevels[tmp] = leftLevels[tmp2];
            leftLevels[tmp2] = tempLvl;
        }    
        leftLevels.Add(0);
        leftLevels.Add(0);      
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
