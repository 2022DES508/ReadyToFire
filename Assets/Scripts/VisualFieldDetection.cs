using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFieldDetection : MonoBehaviour
{
    public List<Ray> rays; 
    private float fieldAngle;
    private Vector3 origin;

    private LineRenderer lr;

    public Gradient lineColor;

    public GameObject Forward;

    private void Start()
    {
        rays = new List<Ray>(); 
        fieldAngle = 30; 

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
        // Debug.Log(Forward.transform.position + "+" + origin);
        Vector3 direction = new Vector3(Forward.transform.position.x - origin.x, 
            0, Forward.transform.position.z - origin.z).normalized;
        Ray ray = new Ray(origin, direction);
        rays.Add(ray);

        Vector3 center = new Vector3(origin.x, 0, origin.z);
        Vector3 point = new Vector3(direction.x, 0, direction.z);

        Vector3 theAxis = new Vector3(origin.x, 1f, origin.z); 

        for (int i = 1; i <= fieldAngle; i++)
        {
            Vector3 newPoint = RotateRound(point, center, theAxis, 0.5f * i);
            direction = new Vector3(newPoint.x, 0, newPoint.z); 
            ray = new Ray(origin, direction);
            // Debug.Log(origin+"+"+direction);  
            rays.Add(ray);
            // Debug.Log(ray); 

            newPoint = RotateRound(point, center, theAxis, -0.5f * i); 
            direction = new Vector3(newPoint.x, 0, newPoint.z);  
            ray = new Ray(origin, direction);
            rays.Add(ray); 
        }

    }

    public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
    {
        Vector3 point = Quaternion.AngleAxis(angle, axis) * (position - center);
        Vector3 resultVec3 = center + point;
        return resultVec3;
    }

    void DrawRays()
    {
        lr.colorGradient = lineColor; 

        int postionCount = 2;
        foreach (var ray in rays)
        {
            // Debug.DrawRay(ray.origin, ray.direction * 10, Color.green); 

            lr.positionCount = postionCount;
            lr.SetPosition(postionCount - 2, ray.origin);
            Vector3 endPoint = ray.GetPoint(10f); 
            lr.SetPosition(postionCount - 1, endPoint); 

            postionCount += 2; 
        }
    }
}
