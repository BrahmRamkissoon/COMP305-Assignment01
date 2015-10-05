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

using UnityEngine;
using System.Collections;

// Destroy any objects which collide with each other
public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;            // Explosion effect for object
    public GameObject playerExplosion;      // Explosion effect for player object explosion

    void OnTriggerEnter(Collider other)
    {
        // Ignore boundary collision
        if (other.tag == "Boundary")
        {
            return;
        }
        // Create explosion at object position, rotation
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Asteroid")
        {
            // need to add code for physcis
            return;
        }

        // Create explosion at player object position, rotation
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);      
        Destroy(gameObject);
        }
}
