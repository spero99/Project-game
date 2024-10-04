using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float healthValue;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")  //collision.gameObject.tag == "Player"
        {
            Debug.Log("Dont touch me");

            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);    
        }
    }
}
