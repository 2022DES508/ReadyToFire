using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPathOfPolice : MonoBehaviour
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

    public void OnClickCancelBtn()
    {
        transform.parent.transform.parent.GetComponent<PoliceMove>().isStop = true;
        GameManager.GM.isShowPoliceUI = false;
    }
}
