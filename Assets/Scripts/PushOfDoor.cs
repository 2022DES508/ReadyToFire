using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOfDoor : MonoBehaviour
{
    public Transform upTransform;
    [SerializeField]
    private float posFixValue;

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
        this.transform.position = new Vector3(screenPos.x, screenPos.y - posFixValue, screenPos.z); 
    }

    public void OnClickPushBtn()
    {
        this.transform.parent.transform.parent.transform.parent.transform.Rotate(transform.up, 90f, Space.Self);
        pushBtn.SetActive(false);
        breakBtn.SetActive(false);
        SoundManager.SM.PlayDoorOpen(); 
    }
}
