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
    // PUBLIC INSTANCE VARIABLES+++++++++++++++++++++++++++
    public Text scoreLabel;
    public Text livesLabel;
    public Text healthLabel;
    
    public int _maxHealth;
    public int hitByAsteroid = 100;
    //public int hitByEnemy = 50;   // not yet implemented

    // PRIVATE INSTANCE VARIABLES+++++++++++++++++++++++++++
    private int _scoreValue;
    private int _livesValue;
    private int _currentHealth;
    private bool isDead;
    private bool isDamaged;
    

    void Awake()
    {
        this._SetGUIValues();
    }
    void Start()
    {
        this._UpdateGUI();
    }

    void Update()
    {
        this._UpdateGUI();
    }

    // Allow other gameObjects to update score value 
    public void AddScore(int newScoreValue)
    {
        this._scoreValue += newScoreValue;
    }

    // Allow other gameObjects to update life value
    public bool RemoveLife()
    {
        if (this._livesValue > 0)
        {
            this._livesValue--;
            return this.isDead = false;
        }
        else
        {
            return this.isDead = true;
        }
    }

    // 
    private void _SetGUIValues()
    {
        this._scoreValue = 0;
        this._livesValue = 3;
        this._currentHealth = _maxHealth;
    }

    private void _UpdateGUI()
    {
        this.scoreLabel.text = "Score: " + this._scoreValue;
        this.livesLabel.text = "Lives: " + this._livesValue;
        this.healthLabel.text = "Health: " + this._currentHealth;
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
        _currentHealth -= amount;
        _UpdateGUI();

        if (_currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    // On player death
    void Death()
    {
        isDead = true;
       
        this._livesValue -= 1;
        _UpdateGUI();
    }

   
}
