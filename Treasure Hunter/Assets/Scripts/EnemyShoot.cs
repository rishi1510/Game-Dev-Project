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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Vector2 curPos = firePoint.position;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bullet.GetComponent<EnemyBullet>().damage = (int) Random.Range(minDamage, maxDamage);
        }

        StartCoroutine(ShootPlayer());
    }
}
