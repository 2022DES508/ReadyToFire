using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombOfPolice : MonoBehaviour
{
    public Transform upTransform;
    [SerializeField]
    private float posFixValue;

    public Transform forwardTransform;

    public GameObject BombPrefab; 

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

    public void OnClickBombBtn()
    {
        Vector3 throwDirection = forwardTransform.position - upTransform.position;
        GameObject newBomb =  Instantiate(BombPrefab, upTransform.position, upTransform.rotation);
        newBomb.GetComponent<Grenade>().SetDirection(throwDirection);

        GameManager.GM.isShowPoliceUI = false; 
    }
}
