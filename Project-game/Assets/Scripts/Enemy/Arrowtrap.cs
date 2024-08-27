using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowtrap : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Quiver;
    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;
        Quiver[FindQuiver()].transform.position = firePoint.position;
        Quiver[FindQuiver()].GetComponent<EnemyProjectile>().ActivateProjectile(); 
    }

    private int FindQuiver()
    {
        for (int i=0; i< Quiver.Length; i++)
        {
            if (!Quiver[i].activeInHierarchy)
                return i;   
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;    

        if (cooldownTimer >= attackCooldown) { 
            //Attack();
            }

    }
}
