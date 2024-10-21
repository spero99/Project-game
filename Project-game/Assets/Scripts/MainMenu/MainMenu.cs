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
    public void PlayGame()
    {

        InitializeLeftLevels();
        //to fix
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        getNextLevelIndex();

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    public static void getNextLevelIndex()
    {
        //gets the next level from the levels available
        int nextLevelIndex = leftLevels[0];
        Debug.Log(nextLevelIndex);
        //removes the level selected from the available levels so we dont replay that level
        leftLevels.RemoveAt(0);
        SceneManager.LoadScene(nextLevelIndex);
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
        Debug.Log(leftLevels);
        
        //leftLevels.Add(0);
        Debug.Log(leftLevels.Count);
        Debug.Log(leftLevels);
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
