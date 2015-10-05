// Source file name: DestroyByBoundary.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Destroy all objects leaving the boundary to optimize memory usage
// Revision history:
using UnityEngine;
using System.Collections;

// Destroy objects leaving boundary 
public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);

    }
}
