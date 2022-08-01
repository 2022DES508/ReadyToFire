using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeOfPolice : MonoBehaviour
{
    public Transform upTransform;
    [SerializeField]
    private float posFixValue;

    public Transform forwardTransform;

    public GameObject SmokePrefab; 

    private void OnEnable()
    {
        ChangePosition();
    }

    void ChangePosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(upTransform.position);
        this.transform.position = new Vector3(screenPos.x, screenPos.y + posFixValue, screenPos.z);
    }

    public void OnClickSmokeBtn() 
    {
        Vector3 throwDirection = forwardTransform.position - upTransform.position;
        GameObject newSmoke = Instantiate(SmokePrefab, upTransform.position, upTransform.rotation);
        newSmoke.GetComponent<Smoke>().SetDirection(throwDirection); 

        GameManager.GM.isShowPoliceUI = false;
    }
}
