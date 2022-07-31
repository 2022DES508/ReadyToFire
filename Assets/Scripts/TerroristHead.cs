using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerroristHead : MonoBehaviour
{
    private VisualFieldDetection vfd;

    private void Start()
    {
        vfd = GetComponent<VisualFieldDetection>(); 
    }

    private void Update()
    {
        PoliceAttributes[] enemies = FindObjectsOfType<PoliceAttributes>();
        PoliceAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        if (firstEnemy != null)
        {
            transform.LookAt(firstEnemy.gameObject.transform);
        }
        DetectEnemy(); 
    }

    PoliceAttributes FindFirstEnemy(PoliceAttributes[] enemies, Transform policePos)
    {
        if (enemies == null || enemies.Length == 0) return null; 

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

    void DetectEnemy()
    {
        GetComponentInParent<TerroristAttributes>().isFire = false; 
        foreach (var ray in vfd.rays)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject.GetComponent<PoliceAttributes>())
                {
                    GetComponentInParent<TerroristAttributes>().isFire = true; 
                }
            }
        }
    }
}
