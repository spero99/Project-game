using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private AudioClip bulletSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {            
            Shoot();
        }
    }


    void Shoot()
    {
        SoundManager.instance.PlaySound(bulletSound);

        //Shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
