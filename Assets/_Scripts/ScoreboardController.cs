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
    public Text restartLabel;
    public Text gameOverLabel;
    
    public int _maxHealth;
    public int hitByAsteroid = 100;
    //public int hitByEnemy = 50;   // not yet implemented

    // PRIVATE INSTANCE VARIABLES+++++++++++++++++++++++++++
    private int _scoreValue;
    private int _livesValue;
    private int _currentHealth;
    
    private bool _isDead;
    private bool _isDamaged;

    private bool _restart;
    private bool _gameOver;
    

    void Awake()
    {
        this._SetGUIValues();
    }

    

    void Update()
    {
        this._UpdateGUI();

        if (_restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (_gameOver)
        {
            gameOverLabel.text = "Game Over!";
        }
    }

    // Allow other gameObjects to update score value 
    public void AddScore(int newScoreValue)
    {
        this._scoreValue += newScoreValue;
    }

    // Allow other gameObjects to update life value
    public bool RemoveLife()
    {
        this._livesValue--;
        if (this._livesValue >= 1)
        {
            return this._isDead = false;
        }
        else
        {
            return this._isDead = true;
        }
    }

    // 
    private void _SetGUIValues()
    {
        this._scoreValue = 0;
        this._livesValue = 3;
        this._currentHealth = _maxHealth;
        this._isDead = false;
        this._isDamaged = false;
        this._gameOver = false;
        this._restart = false;
    }

    private void _UpdateGUI()
    {
        this.scoreLabel.text = "Score: " + this._scoreValue;
        this.livesLabel.text = "Lives: " + this._livesValue;
        this.healthLabel.text = "Health: " + this._currentHealth;
    }

    public bool IsGameOver()
    {
        return this._gameOver;
    }

    public void GameOver()
    {
        gameOverLabel.text = "Game Over!";
        _gameOver = true;
    }
    public void SetRestart(bool restart)
    {
        this._restart = true;
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
        _isDamaged = true;
        _currentHealth -= amount;
        _UpdateGUI();

        if (_currentHealth <= 0 && !_isDead)
        {
            Death();
        }
    }

    // On player death
    void Death()
    {
        _isDead = true;
       
        this._livesValue -= 1;
        _UpdateGUI();
    }

   
}
