using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerroristAttributes : MonoBehaviour
{
    public float healthyMax;
    [HideInInspector]
    public float healthyNow;

    public float moveSpeed;
    public float steeringSpeed;
    public float reactionAimingSpeed;
    public float magazineChangeSpeed;

    public float meleeDamage;
    public float fireRate;
    public float shootingAccuracy; 

}
