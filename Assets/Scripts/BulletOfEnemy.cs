using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOfEnemy : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    public void SetSpeed(Vector3 direction)
    {
        rb.velocity = direction * speed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Police")
            Destroy(gameObject); 
    }
}
