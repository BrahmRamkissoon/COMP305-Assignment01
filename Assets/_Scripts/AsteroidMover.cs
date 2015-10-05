// Source file name: AsteroidMover.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Randomize asteroid movement along Z axis
// Revision history:

using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour
{

    // move automatically on game start
    void Start()
    {
        // Set asteroid movement speed randomly along the z axis between -4.0 and -7.0
        GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(-4.0F, -7.0F);
        
    }
}
