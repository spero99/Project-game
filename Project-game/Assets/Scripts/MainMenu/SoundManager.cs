using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Debug.Log("Soundmanager awake");
        instance = this;

        /*
         //Keep this object even when we go to new scene
         if (instance == null)
         {
             Debug.Log("SM instance == null");
             instance = this;
             DontDestroyOnLoad(gameObject);
         }
         //Destroy duplicate gameobjects
         else if (instance != null && instance != this)
         {
             Debug.Log("SM instance != null, destroy instance  ");
             Destroy(gameObject);
         }
        */

    }
    public void PlaySound(AudioClip _sound)
    {
        Debug.Log("SM sound playing ");
        source.PlayOneShot(_sound);

    }
}