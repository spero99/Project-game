using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float healthValue;


    private void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")  //collision.gameObject.tag == "Player"
        {
            Debug.Log("Dont touch me");

            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
