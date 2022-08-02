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

        // TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>();
        // TerroristAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);

        DetectEnemy(); 

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

    void DetectEnemy()
    {
        GetComponentInParent<PoliceAttributes>().isFire = false;

        GameObject minEnemy = null;  
        float minDistance = float.MaxValue;  

        foreach (var ray in vfd.rays)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject.GetComponent<TerroristAttributes>())
                {
                    float thisDistance = Vector3.Distance(hit.collider.gameObject.transform.position, this.transform.position); 
                    if (thisDistance < minDistance)
                    {
                        minEnemy = hit.collider.gameObject;
                        minDistance = thisDistance; 
                    }
                }
            }
        }
        if (minEnemy != null)
        {
            GetComponentInParent<PoliceAttributes>().isFire = true;
            minEnemy.GetComponent<TerroristAttributes>().isShow = true;

            transform.LookAt(minEnemy.transform); 
        }
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
