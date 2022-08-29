using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lr; 

    [HideInInspector]
    public List<Vector3> points = new List<Vector3>();
    [HideInInspector]
    public int pointsCount = 0;

    // 直线各点之间的最小距离 
    float pointsMinDistance = 0.1f;

    private float existTimer;

    private void Start()
    {
        existTimer = 10; 
    }

    private void Update()
    {
        ExistenceCheck(); 
    }

    void ExistenceCheck()
    {
        existTimer -= Time.deltaTime; 
        if (existTimer <= 0)
        {
            Destroy(transform.gameObject); 
        }
    }

    // 画点，连线
    public void AddPoint (Vector3 newPoint)
    {
        if (pointsCount >= 1 && Vector3.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return; 
        points.Add(newPoint); 
        pointsCount++;

        // 更新画线渲染器
        lr.positionCount = pointsCount;
        lr.SetPosition(pointsCount - 1, newPoint);

    }

    public Vector3 GetLastPoint()
    {
        return (Vector3)lr.GetPosition(pointsCount - 1); 
    }

    // ---------- Set 函数 -----------------------------------------
    public void SetLineColor (Gradient colorGradient)
    {
        lr.colorGradient = colorGradient; 
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance; 
    }

    public void SetLineWidth (float width)
    {
        lr.startWidth = width;
        lr.endWidth = width;
    }

}
