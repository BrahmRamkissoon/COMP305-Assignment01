// Source file name: DestroyByContact.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Object collisions should have explosions, exceptions below:
//      Asteroid to Asteroid
//      Object to Boundary 
// Revision history:    -   all collisions produce explosions except with Boundary
//                      -   added explosion exception: asteroid to asteroid collisions
//                      -   added check if player is alive to work with scoring

using UnityEngine;
using System.Collections;

// Destroy any objects which collide with each other
public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion; // Explosion effect for asteroid object
    public GameObject playerExplosion; // Explosion effect for _player object explosion

    public int scoreValue; // Score value for destroying an asteroid object 
    private ScoreboardController _scoreboardController; // Hold reference to GameController


    private void Start()
    {
        // Find reference of ScoreboardController and assign to _scoreboardController
        GameObject scoreboardControllerObject = GameObject.FindGameObjectWithTag("ScoreboardController");
        if (scoreboardControllerObject != null)
        {
            _scoreboardController = scoreboardControllerObject.GetComponent<ScoreboardController>();
        }
        if (scoreboardControllerObject == null)
        {
            Debug.Log("Cannot find 'ScoreboardController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // Ignore collision with Boundary
        if (other.tag == "Boundary" || other.tag == "Asteroid")
        {
            return;
        }
        // Create explosion at asteroid object position, rotation
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            
            // check we have enough lives and remove life if _player is not dead
            if (this._scoreboardController.RemoveLife() != true)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject); // player object is destroyed
                Destroy(gameObject); // asteroid object is destroyed
                _scoreboardController.GameOver();
                return;
            }
        }

        _scoreboardController.AddScore(scoreValue);
        Destroy(other.gameObject); // player bolt object is destroyed
        Destroy(gameObject); // asteroid object is destroyed
    }
}
