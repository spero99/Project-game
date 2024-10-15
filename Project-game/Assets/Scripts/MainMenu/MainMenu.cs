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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    public static void getNextLevelIndex()
    {
        //

    }
    public static void InitializeLeftLevels()
    {
        //
        leftLevels = new List<int> {  1, 2, 3, 4 };
        //randomize
        for( int i = 0; i<69; i++)
        {
            int tmp  = Random.Range(0, leftLevels.Count);
            int tmp2 = Random.Range(0, leftLevels.Count);
            int tempLvl = leftLevels[tmp];
            leftLevels[tmp] = leftLevels[tmp2];
            leftLevels[tmp2] = tempLvl;
            
        }
        Debug.Log(leftLevels);
        //leftLevels.Add(5);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
