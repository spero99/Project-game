using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]public float speed = 20f;
    [SerializeField] public int damage;
    
    public Rigidbody2D rb;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    private float lifetime;
    
    private bool impact = false;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float direction;

    // Start is called before the first frame update
    private void Awake()
    {
        lifetime = 0;
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
       
    }
    private void Update()
    {
        
        rb.velocity = transform.right * speed;

        if (impact) 
        {
            rb.velocity = transform.right * 0f;
            lifetime += Time.deltaTime;
            gameObject.SetActive(false);
            
            impactEffect.SetActive(false);
            //Debug.Log("set inactive");
        }
        if (lifetime > 3)
            gameObject.SetActive(false);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        impact = true;
        //Debug.Log("impact");
        //Debug.Log(collision.name);
        speed = 0f;
        
        Instantiate(impactEffect, transform.position, transform.rotation);
        if (lifetime > 1) 
            impactEffect.SetActive(false);


        
         if (collision.name == "meleeEnemy")
         {
           
            //enemy.TakeDamage(damage);
            collision.GetComponent<Health>().TakeDamage(1);
            //Debug.Log("damage taken");
           
         }
    
            
        
       

        
    }

   
}
