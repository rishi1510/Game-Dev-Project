using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform player;
    public float bulletForce = 20;
    public float minDamage = 2, maxDamage = 15;
    public float minCoolDown, maxCooldown;
    public float rotation = 0;
    public bool spreadShot;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ShootPlayer());
    }

    void Update() {
        if(player == null) {
            StopCoroutine(ShootPlayer());
        }
    }

    IEnumerator ShootPlayer() {
        float cooldown = Random.Range(minCoolDown, maxCooldown);
        yield return new WaitForSeconds(cooldown);

        if(player != null) {
            if(spreadShot) {
                GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, rotation));
                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                bullet1.transform.Rotate(0, 0, 15);
                rb1.AddForce(bullet1.transform.right * bulletForce, ForceMode2D.Impulse);
                bullet1.GetComponent<EnemyBullet>().damage = (int) Random.Range(minDamage, maxDamage);

                GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, rotation));
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                rb2.AddForce(bullet2.transform.right * bulletForce, ForceMode2D.Impulse);
                bullet2.GetComponent<EnemyBullet>().damage = (int) Random.Range(minDamage, maxDamage);

                GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, rotation));
                Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
                bullet3.transform.Rotate(0, 0, -15);
                rb3.AddForce(bullet3.transform.right * bulletForce, ForceMode2D.Impulse);
                bullet3.GetComponent<EnemyBullet>().damage = (int) Random.Range(minDamage, maxDamage);
            }
            else {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, rotation));
                Vector2 curPos = firePoint.position;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                bullet.GetComponent<EnemyBullet>().damage = (int) Random.Range(minDamage, maxDamage);
            }
        }

        StartCoroutine(ShootPlayer());
    }
}
