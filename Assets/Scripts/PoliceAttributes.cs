using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAttributes : MonoBehaviour
{

    public float healthyMax; 
    [HideInInspector]
    public float healthyNow; 

    public float armourMax; 
    [HideInInspector] 
    public float armourNow; 

    public float moveSpeed;
    public float steeringSpeed;
    public float reactionAimingSpeed;
    public float magazineChangeSpeed;
    public float weaponChangeSpeed;

    public float meleeDamage;
    public float fireRate;

    private void OnMouseEnter()
    {
        GameManager.GM.isDraw = true; 
    }
    private void OnMouseExit()
    {
        GameManager.GM.isDraw = false; 
    }
}
