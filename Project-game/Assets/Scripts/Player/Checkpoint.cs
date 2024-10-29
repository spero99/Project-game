
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

    public void GameWonScreen()
    {
        uiManager.GameWon();
    }
    //Checkpoint Activation
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint" )
        {
            Debug.Log("checkpoint Collision");
            int nextlvl = MainMenu.GetNextLevelIndex();
            Debug.Log("nextlvlis:");
            Debug.Log(nextlvl);
            if (nextlvl == 0)
            {
                uiManager.GameWon();
            }
            else
            {
                SceneManager.LoadScene(nextlvl);
            }
        }
    }
}



