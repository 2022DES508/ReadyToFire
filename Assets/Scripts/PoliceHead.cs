using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceHead : MonoBehaviour
{
    private VisualFieldDetection vfd;

    private void Start()
    {
        vfd = GetComponent<VisualFieldDetection>();
    }

    private void Update()
    {
        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>();
        TerroristAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        // transform.LookAt(firstEnemy.gameObject.transform);  
        DetectEnemy(); 
    }

    TerroristAttributes FindFirstEnemy(TerroristAttributes[] enemies, Transform policePos)
    {
        float minDistance = Vector3.Distance(enemies[0].transform.position, policePos.position);
        TerroristAttributes finalEnemy = enemies[0];

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
        foreach (var ray in vfd.rays)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject.GetComponent<TerroristAttributes>())
                {
                    hit.collider.gameObject.GetComponent<TerroristAttributes>().isShow = true; 
                }
            }
        }
    }
}
