using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    public GameObject linePrefab;

    [Space(20f)]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;
    public GameObject pencil;

    Line currentLine;
    Vector3 drawPoint;
    bool isChangePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GM.isDraw) 
            BeginDraw(); 
        if (currentLine != null) 
            Draw(); 
        if (Input.GetMouseButtonUp(0)) 
            EndDraw(); 
    }

    GameObject obj = null; 
    void BeginDraw()
    {
        Time.timeScale = 0f; 

        GetDrawPoint();

        obj = Instantiate(pencil, drawPoint, transform.rotation);
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth); 
    }

    void Draw()
    {
        isChangePoint = false; 
        GetDrawPoint();
        if (!isChangePoint) return; 

        obj.transform.position = drawPoint;
        currentLine.AddPoint(drawPoint); 
    }

    void EndDraw()
    {
        if (currentLine != null)
        {
            GameManager.GM.currentPA.SetPath(currentLine.points); 

            if (currentLine.pointsCount < 2)
            {
                Destroy(currentLine.gameObject); 
            }
            else
            {
                GameManager.GM.currentLine = currentLine.gameObject; 
                currentLine = null; 
            }
        }
        Destroy(obj);

        Time.timeScale = 1f; 
    }

    void GetDrawPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit(); 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name == "Plane")
            {
                drawPoint = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z); 
                isChangePoint = true; 
            }
        }
    }
}
