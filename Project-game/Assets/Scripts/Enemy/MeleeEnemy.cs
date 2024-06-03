using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerLayer;// this might cause problems
    [SerializeField] private BoxCollider2D boxCollider;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer = Time.deltaTime;

        //attack 
        if (cooldownTimer >= attackCooldown)
        {

        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,
            0,Vector2.left,0,playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
