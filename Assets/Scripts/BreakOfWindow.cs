using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOfWindow : MonoBehaviour
{
    public Transform upTransform;

    private void OnEnable()
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
        Destroy(transform.parent.transform.parent.gameObject); 
    }
}
