using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public GameObject options;

    public void ShowOptions()
    {
        options.SetActive(true); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PoliceAttributes>())
        {
            Time.timeScale = 0;
            ShowOptions(); 
        }
    }

    public void OnClickBreak()
    {
        Time.timeScale = 1;
        Destroy(gameObject); 
    }
}
