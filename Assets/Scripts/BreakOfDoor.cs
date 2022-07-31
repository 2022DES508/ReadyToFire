using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOfDoor : MonoBehaviour
{
    public Transform upTransform;
    [SerializeField]
    private float posFixValue; 

    private void OnEnable()
    {
        ChangePosition();
    }

    void ChangePosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(upTransform.position);
        this.transform.position = new Vector3(screenPos.x, screenPos.y + posFixValue, screenPos.z); 
    }

    public void OnClickBreakBtn()
    {
        Destroy(transform.parent.transform.parent.transform.parent.gameObject); 
    }
}
