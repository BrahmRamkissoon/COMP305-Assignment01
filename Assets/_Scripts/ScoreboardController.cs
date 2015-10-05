// Source file name: ScoreboardController.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 05/10/2015
// Date last Modified: 
// File description: Handle the scoreboard display
// Revision history:
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardController : MonoBehaviour
{

    public Text scoreLabel;
    public Text livesLabel;
    public Text healthLabel;

    public int scoreValue = 0;

    public int livesValue = 5;
    public int maxHealth = 100;
    public int currentHealth;
    public int hitByAsteroid = 100;

    private bool isDead;
    private bool isDamaged;
    //public int hitByEnemy = 50;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        this._SetScore();
    }

    private void _SetScore()
    {
        this.scoreLabel.text = "Score: " + this.scoreValue;
        this.livesLabel.text = "Lives: " + this.livesValue;
        this.healthLabel.text = "Health: " + this.currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        // Hit by Asteroid
        if (other.tag == "Asteroid")
        {
            TakeDamage(hitByAsteroid);
        }
    }

    void TakeDamage(int amount)
    {
        isDamaged = true;
        currentHealth -= amount;
        _SetScore();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    // On player death
    void Death()
    {
        isDead = true;
       
        this.livesValue -= 1;
        _SetScore();
    }
    
}
