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

    public bool isShow;

    private void Start()
    {
        isShow = false; 
    }
    private void Update()
    {
        PoliceAttributes[] enemies = FindObjectsOfType<PoliceAttributes>();
        PoliceAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        MeshRenderer[] allRenderers = transform.GetComponentsInChildren<MeshRenderer>();
        // if (Vector3.Distance(firstEnemy.transform.position, transform.position) > 10)
        if (!isShow) 
        {
            HideRenderers(allRenderers);
            firstEnemy.isFire = false; 
        }
        else
        {
            ShowRenderers(allRenderers);
            firstEnemy.isFire = true; 
            isShow = false; 
        }
    }

    void HideRenderers(MeshRenderer[] allRenderers) 
    {
        for (int i = 0; i < allRenderers.Length; i++)
        {
            allRenderers[i].enabled = false; 
        }
    }

    void ShowRenderers(MeshRenderer[] allRenderers)
    {
        for (int i = 0; i < allRenderers.Length; i++)
        {
            allRenderers[i].enabled = true; 
        }
    }

    PoliceAttributes FindFirstEnemy(PoliceAttributes[] enemies, Transform policePos)
    {
        float minDistance = Vector3.Distance(enemies[0].transform.position, policePos.position);
        PoliceAttributes finalEnemy = enemies[0];

        for (int i = 0; i < enemies.Length; i++)
        {
            float nextDistance = Vector3.Distance(enemies[i].transform.position, policePos.position);
            if (nextDistance < minDistance)
            {
                finalEnemy = enemies[i];
                minDistance = nextDistance;
            }
        }

        return finalEnemy;
    }

}
