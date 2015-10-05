// Source file name: AsteroidMover.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Randomize asteroid movement along Z axis
// Revision history:    -   hardcoded random min and max speed
//                      -   added public variables speedMin, speedMax

using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour
{
    public float speedMin, speedMax;

    // move automatically on game start
    void Start()
    {
        // Set asteroid movement speed randomly along the z axis 
        GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(speedMin, speedMax);
        
    }
}
