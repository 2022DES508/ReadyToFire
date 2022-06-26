using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFieldDetection : MonoBehaviour
{
    private List<Ray> rays; 
    private float fieldAngle;
    private float addHighOfAngle; 
    private Vector3 origin;

    private LineRenderer lr;

    public Gradient lineColor; 

    private void Start()
    {
        rays = new List<Ray>(); 
        fieldAngle = 30;
        addHighOfAngle = (Mathf.Tan(((fieldAngle/2)*Mathf.PI)/180))/(fieldAngle);

        lr = GetComponent<LineRenderer>(); 
    }

    private void Update()
    {
        CreateRays();
        DrawRays(); 
    }

    void CreateRays()
    {
        if (rays.Count != 0) rays.Clear(); 

        origin = transform.position; 
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 direction = new Vector3(forward.x, forward.y, forward.z).normalized;   
        Ray ray = new Ray(origin, direction);
        rays.Add(ray); 

        for (int i = 1; i < fieldAngle; i++)
        {
            direction = new Vector3(forward.x, forward.y, forward.z + addHighOfAngle * i).normalized;
            ray = new Ray(origin, direction);
            rays.Add(ray);

            direction = new Vector3(forward.x, forward.y, forward.z - addHighOfAngle * i).normalized; 
            ray = new Ray(origin, direction);
            rays.Add(ray); 
        }

    }

    void DrawRays()
    {
        lr.colorGradient = lineColor; 

        int postionCount = 2;
        foreach (var ray in rays)
        {
            // Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            lr.positionCount = postionCount;
            lr.SetPosition(postionCount - 2, ray.origin);
            Vector3 endPoint = ray.origin + ray.direction * 10;
            lr.SetPosition(postionCount - 1, endPoint); 

            postionCount += 2; 
        }
    }
}
