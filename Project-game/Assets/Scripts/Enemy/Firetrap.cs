using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float fireTrapDamage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trap gets triggered 
    private bool active; // when the trap is activated and can hurt the player



    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(fireTrapDamage);
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        //turn color to red for visual warning

        spriteRend.color= Color.red;
        //wait for delay
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);
        //active time of the trap(burn in period)
        yield return new WaitForSeconds(activeTime);
        active = false;
        anim.SetBool("activated", false);

        triggered = false;
    }
}
