// Source file name: DestroyByTime.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 04/10/2015
// Date last Modified: 
// File description: Destroy objects to optimize memory management
// Revision history:
using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{

    public float lifetime;      // time to live 

	// Use this for initialization
	void Start () {
	    Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
