// Source file name: BGScroller.cs
// Author: Brahm Ramkissoon
// 
// Last Modified by: Brahm Ramkissoon
// Date created: 01/10/2015
// Date last Modified: 
// File description: Scroll the background
// Revision history:

// Reference: https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/2d-scrolling-backgrounds

using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float ScrollSpeed;       // Set scroll speed of quad
    public float TileSizeZ;         // Size of tile

    private Vector3 _startPosition;


	// Use this for initialization
	void Start ()
	{
	    _startPosition = GetComponent<Transform>().position;    // get position of quad
	}
	
	// Update is called once per frame
	void Update () {
	    float newPosition = Mathf.Repeat(Time.time * ScrollSpeed, TileSizeZ);     // never exceed length of tile 
        transform.position = _startPosition + Vector3.forward * newPosition;    // reset quad position
	
	}
}
