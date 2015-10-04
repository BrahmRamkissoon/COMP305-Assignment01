// Source file name: Mover.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: 
// Revision history:
using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float speed;         // control speed of object

    // move automatically on game start
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
