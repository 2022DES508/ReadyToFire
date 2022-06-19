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

    [HideInInspector]
    public List<Vector3> path;
    [HideInInspector]
    public bool startMove;
    public bool endMove; 

    private void OnMouseEnter()
    {
        GameManager.GM.isDraw = true;
        GameManager.GM.currentPA = this; 
    }
    private void OnMouseExit()
    {
        GameManager.GM.isDraw = false; 
    }

    public void SetPath(List<Vector3> points)
    {
        path = new List<Vector3>(points.ToArray());
        startMove = true; 
    }
}
