using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject BreakBtn; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PoliceAttributes>() != null)
        {
            BreakBtn.SetActive(true); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PoliceAttributes>() != null)
        {
            BreakBtn.SetActive(true); 
        }
    }
}
