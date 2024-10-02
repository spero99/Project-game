using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private AudioClip deathSound;

    public GameObject deathEffect;
    public Scoring Scoring;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Scoring.ScoreNum += 100;
            SoundManager.instance.PlaySound(deathSound);
        }

    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}

