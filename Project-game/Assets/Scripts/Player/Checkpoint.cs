
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    //Progress to next level
    [SerializeField] private AudioClip checkpointSound; // beep beep you did it 
    private Transform currentCheckpoint; //store last checkpoint place 
    private Health playerHealth;
    private UIManager uiManager;
    private bool testingOneMap = true;
    [SerializeField] private Text score;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();  
    }

    public void Respawn() // will become progress to nxt lvl
    {
        /*
        //move player to checkpoint position 
        transform.position = currentCheckpoint.position; 

        // load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        */

        //for test only go to main menu 
        SceneManager.LoadScene(0);


        //Restore player health and animation 
        playerHealth.Respawn();
    }

    //Checkpoint Activation
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint" )
        {
            uiManager.GameWon();
        }
        /*
        if (collision.transform.tag == "Checkpoint" && testingOneMap == true)
        {
            uiManager.GameWon();
        }


        if (collision.transform.tag == "Checkpoint" && testingOneMap ==false)
        {
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            
            Debug.Log("appear");
            
        }
        */
    }
}



