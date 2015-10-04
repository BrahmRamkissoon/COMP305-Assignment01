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
