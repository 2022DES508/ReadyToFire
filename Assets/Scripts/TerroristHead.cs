using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerroristHead : MonoBehaviour
{
    private void Update()
    {
        PoliceAttributes[] enemies = FindObjectsOfType<PoliceAttributes>();
        PoliceAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        transform.LookAt(firstEnemy.gameObject.transform);  
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
