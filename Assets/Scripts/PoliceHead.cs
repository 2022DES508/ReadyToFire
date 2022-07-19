using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceHead : MonoBehaviour
{
    private VisualFieldDetection vfd;
    private LineRenderer lr; 

    private void Start()
    {
        vfd = GetComponent<VisualFieldDetection>();
        lr = GetComponent<LineRenderer>(); 
    }

    private void Update()
    {
        SelfRotate(); 

        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>();
        TerroristAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        if (firstEnemy)
        {
            if (DetectEnemy())
                transform.LookAt(firstEnemy.gameObject.transform);
        }
        if (GetComponentInParent<PoliceAttributes>().isFire)
            lr.enabled = false;
        else
            lr.enabled = true; 
    }

    TerroristAttributes FindFirstEnemy(TerroristAttributes[] enemies, Transform policePos)
    {
        if (enemies.Length <= 0) return null; 
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

    bool DetectEnemy()
    {
        bool isture = false; 
        foreach (var ray in vfd.rays)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject.GetComponent<TerroristAttributes>())
                {
                    hit.collider.gameObject.GetComponent<TerroristAttributes>().isShow = true;
                    isture = true; 
                }
            }
        }
        return isture; 
    }

    void SelfRotate()
    {
        // if (!GetComponentInParent<PoliceAttributes>().isControl) return; 

        float rotateSpeed = 90f; 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime, Space.Self); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.Self); 
        }
    }


}
