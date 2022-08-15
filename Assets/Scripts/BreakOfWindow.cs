using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOfWindow : MonoBehaviour
{
    public Transform upTransform;
    public GameObject thisWindow;

    public GameObject breakBtn;

    private void OnEnable()
    {
        ChangePosition(); 
    }

    private void Update()
    {
        ChangePosition();
    }

    void ChangePosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(upTransform.position); 
        this.transform.position = screenPos; 
    }

    public void OnClickBreakBtn()
    {
        // Destroy(transform.parent.transform.parent.gameObject); 

        breakBtn.SetActive(false);

        transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = false;
        Destroy(thisWindow); 
    }
}
