using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20;
    public float minDamage = 20;
    public float maxDamage = 50;
 
    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            fireBullet();
        }
    }

    void fireBullet() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = (int) Random.Range(minDamage, maxDamage);
    }
}
