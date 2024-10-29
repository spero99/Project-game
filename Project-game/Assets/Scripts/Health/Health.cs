using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField]private UIManager uiManager;
    [SerializeField] private AudioClip deathSound;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public Scoring Scoring;
    public Scoring PlayerScoreText;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    private int points;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
  
    public void TakeDamage(float _damage)
    {
        //if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // no hurt animations because of lack of sprites
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                //play death sound
                SoundManager.instance.PlaySound(deathSound);
                //Scoring.ScoreNum += 100;
                points = PlayerPrefs.GetInt("HighScore");
                points = points + 100;
                PlayerPrefs.SetInt("HighScore", points);
                Debug.Log("kill points");
                Scoring.PlayerScoreText.text = "Score: " + points;
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;
                dead = true;
                
            }
        }
    }
    public void YouDied()
    {
        //back to the lobby you go 
        SoundManager.instance.PlaySound(deathSound);
        uiManager.GameOver();
        // restarting level (softcore)
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    
    public void AddHealth(float _value)
    {
        //medpacks
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}