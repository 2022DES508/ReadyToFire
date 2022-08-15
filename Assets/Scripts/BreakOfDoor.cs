using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOfDoor : MonoBehaviour
{
    public Transform upTransform;
    [SerializeField]
    private float posFixValue;

    public GameObject thisDoor;

    public GameObject pushBtn;
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
        this.transform.position = new Vector3(screenPos.x, screenPos.y + posFixValue, screenPos.z); 
    }

    public void OnClickBreakBtn()
    {
        // Destroy(transform.parent.transform.parent.transform.parent.gameObject); 

        pushBtn.SetActive(false);
        breakBtn.SetActive(false);

        transform.parent.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled = false;
        // Debug.Log(transform.parent.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled); 
        Destroy(thisDoor); 
    }
}
