using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFieldDetection : MonoBehaviour
{
    private List<Ray> rays; 
    private float fieldAngle;
    private float addHighOfAngle; 
    private Vector3 origin;

    private void Start()
    {
        rays = new List<Ray>(); 
        fieldAngle = 30;
        addHighOfAngle = (Mathf.Tan(((fieldAngle/2)*Mathf.PI)/180))/(fieldAngle/2);
    }

    private void Update()
    {
        CreateRays();
        DrawRays(); 
    }

    void CreateRays()
    {
        if (rays.Count != 0) rays.Clear(); 
        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)0.2); 

        Vector3 direction = new Vector3(1, 0, 0).normalized;
        Ray ray = new Ray(origin, direction);
        rays.Add(ray); 

        for (int i = 1; i < fieldAngle / 2; i++)
        {
            direction = new Vector3(1, 0, addHighOfAngle * i).normalized;
            ray = new Ray(origin, direction);
            rays.Add(ray);

            direction = new Vector3(1, 0, -addHighOfAngle * i).normalized;
            ray = new Ray(origin, direction);
            rays.Add(ray); 
        }

    }

    void DrawRays()
    {
        foreach (var ray in rays)
        {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);  
        }
    }
}
