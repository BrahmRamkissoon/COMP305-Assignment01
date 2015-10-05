// Source file name: PlayerController.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: control the player object
// Revision history: 04/10/2015 - added instantiation of shots
//                   05/10/2015 - added audio on weapon fire
using UnityEngine;
using System.Collections;

// Define boundaries of visible play area
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;    
}

[System.Serializable]
public class Spaceship
{
    public float speed;         // Set the movement speed of player object
    public float xTilt;         // tilt player object on z axis
    public float zTilt;         // tilt player object on y axis

    public GameObject shot;     // laser bolt object
    public Transform shotSpawn; // spawn location of laser bolt object

    public float fireRate;      // rate of fire
    protected internal float _nextFire;    // time before next shot
}

public class PlayerController : MonoBehaviour {

    
    public Boundary boundary;   // Create instance of Boundary
    public Spaceship spaceship; // Create instance of Spaceship
    

    void Update()
    {
        // check if fire button is pressed and fire only if enough time has passed
        if (Input.GetButton("Fire1") && Time.time > spaceship._nextFire)
        {
            spaceship._nextFire = Time.time + spaceship.fireRate;
            Instantiate(spaceship.shot, spaceship.shotSpawn.position, spaceship.shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // increase player object movement speed
        GetComponent<Rigidbody>().velocity = movement * spaceship.speed;

        // prevent player object from leaving visible area
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        // simulate forward and sideways physics with tilt along z and x axes
        // based on player velocity along x and z axes respectively
        GetComponent<Rigidbody>().rotation = Quaternion.Euler
            (
                GetComponent<Rigidbody>().velocity.z * spaceship.zTilt, 
                0.0f, 
                GetComponent<Rigidbody>().velocity.x * -spaceship.xTilt
            );


    }
}
