using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badGuyBehaviour : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] public float attackCooldown;
    [SerializeField] public float range;

    [SerializeField] public int damage;

    [Header("Collider Parameters")]
    [SerializeField] public float colliderDistance;
    [SerializeField] public LayerMask playerLayer;// this might cause problems
    [SerializeField] public BoxCollider2D boxCollider;

    private float cooldownTimer = Mathf.Infinity;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    //for later 
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            Debug.Log("I see you");
            //attack only when player in sight

            if (cooldownTimer >= attackCooldown)
            {
                //attack
                cooldownTimer = 0;
                anim.SetTrigger("enemy_attack");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            //if player still in range unalive him 
            playerHealth.TakeDamage(damage);
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}