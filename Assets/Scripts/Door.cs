using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject BreakBtn;
    public GameObject PushBtn; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PoliceAttributes>() != null)
        {
            BreakBtn.SetActive(true);
            PushBtn.SetActive(true); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PoliceAttributes>() != null)
        {
            BreakBtn.SetActive(true); 
            PushBtn.SetActive(true);
        }
    }
}
