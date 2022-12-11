using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public HealthBar healthBar;
    public ClearedRooms rooms;
    public AmmoCount ammoCount;
    public Timer timer;
    public GameOverPanel gameOverPanel;
    public GameObject player;
    public float health, maxHealth, ammo, maxAmmo, clearedRooms = 0, numRooms, damageMultiplier;
    public SpawnRooms spawnRooms;
    public bool hasKey = false, inBattle;
    public GameObject key, multiplierIcon;

    void Awake() {
        if(playerStats != null) {
            Destroy(playerStats);
        }
        else {
            playerStats = this;
        }
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        healthBar.setMaxHealth(health, maxHealth);
        ammo = maxAmmo;
        ammoCount.setAmmoCount(ammo, maxAmmo);
        clearedRooms = 0;
        numRooms = spawnRooms.numRooms;
        rooms.setRoomNo(0, numRooms);
        damageMultiplier = 1;
        hasKey = false;
        inBattle = false;
    }

    public void dealDamage(float damage) {
        health -= damage;
        healthBar.setHealth(health);
        checkDeath();
    }

    public void pickupKey() {
        hasKey = true;
        key.SetActive(true);
    }

    public void setdamageMultiplier(float mult) {
        damageMultiplier += mult;
        multiplierIcon.GetComponent<TextMeshProUGUI>().SetText("x" + damageMultiplier.ToString());
    }

    public void increaseMaxHealth(float hp) {
        maxHealth += hp;
        healCharacter(hp);
        healthBar.setMaxHealth(health, maxHealth);
    }

    public void healCharacter(float heal) {
        health += heal;
        if(health > maxHealth) {
            health = maxHealth;
        }
        healthBar.setHealth(health);
    }

    public void setAmmo(float val) {
        ammo -= val;
        if(ammo < 0) {
            ammo = 0;
        }
        ammoCount.setAmmoCount(ammo, maxAmmo);
    }

    public void ammoPickup(float val) {
        ammo += val;
        if(ammo > maxAmmo) {
            ammo = maxAmmo;
        }
        ammoCount.setAmmoCount(ammo, maxAmmo);
    }

    public void updateRoomCount() {
        rooms.setRoomNo(clearedRooms, numRooms);

        /*if(clearedRooms == numRooms) {
            timer.stopTimer = true;
            gameOverPanel.gameOver();
            Cursor.visible = true;
        }*/
    }

    private void checkDeath() {
        if(health <= 0) {
            health = 0;
            healthBar.setHealth(health);
            Destroy(player);
            //SceneManager.LoadScene(0);
            timer.stopTimer = true;
            gameOverPanel.gameOver();
            Cursor.visible = true;
        }
    }

    public void gameOver() {
        Destroy(player);
        //SceneManager.LoadScene(0);
        timer.stopTimer = true;
        gameOverPanel.gameOver();
        Cursor.visible = true;
    }
}
