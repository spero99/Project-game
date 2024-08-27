using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : TrapDamage //will dmg the player every time they touch
{
    //damage variable is inherited from trap damage script
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;

    private float lifetime;

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed,0, 0);

        lifetime+= Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        gameObject.SetActive(false);//deactivates when hit anything 



    }
}
