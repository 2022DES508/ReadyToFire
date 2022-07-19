using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (other.tag == "Enemy")
        {
            other.GetComponent<TerroristAttributes>().healthyNow -= 1; 
            Destroy(gameObject);
        }
    }
}
