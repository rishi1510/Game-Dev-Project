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
    public float fireRate = 0.3f;
    private float nextFire = 0.0F;
    public float fireMode = 1;

    void Update() {
        if(Input.GetKeyDown("1")) {
            fireMode = 1;
            fireRate = 0.3f;
            minDamage = 40;
            maxDamage = 60;
        }

        else if(Input.GetKeyDown("2")) {
            fireMode = 2;
            fireRate = 0.5f;
            minDamage = 20;
            maxDamage = 30;
        }

        else if(Input.GetKeyDown("3")) {
            fireMode = 3;
            fireRate = 0.1f;
            minDamage = 10;
            maxDamage = 20;
        }

        if(Input.GetButton("Fire1") && Time.time > nextFire && PlayerStats.playerStats.ammo >= 1) {
            nextFire = Time.time + fireRate;
            if(fireMode == 2 && PlayerStats.playerStats.ammo >= 3) {
                fireSpread();

            }
            else {
                fireBullet();
            }
        }
    }

    void fireBullet() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = (int) Random.Range(minDamage, maxDamage);

        PlayerStats.playerStats.setAmmo(1);
    }

    void fireSpread() {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        bullet1.transform.Rotate(0, 0, 10);
        rb1.AddForce(bullet1.transform.up * bulletForce, ForceMode2D.Impulse);
        bullet1.GetComponent<Bullet>().damage = (int) Random.Range(minDamage, maxDamage);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(bullet2.transform.up * bulletForce, ForceMode2D.Impulse);
        bullet2.GetComponent<Bullet>().damage = (int) Random.Range(minDamage, maxDamage);

        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        bullet3.transform.Rotate(0, 0, -10);
        rb3.AddForce(bullet3.transform.up * bulletForce, ForceMode2D.Impulse);
        bullet3.GetComponent<Bullet>().damage = (int) Random.Range(minDamage, maxDamage);

        PlayerStats.playerStats.setAmmo(3);
    }
}
