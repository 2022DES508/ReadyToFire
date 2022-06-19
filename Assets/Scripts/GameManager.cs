using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public bool isDraw;

    public PoliceAttributes currentPA;
    public GameObject currentLine; 

    private void OnEnable()
    {
        if (GameManager.GM == null)
            GameManager.GM = this; 
    }

    private void Update()
    {
        if (currentPA && currentPA.endMove)
        {
            currentPA.endMove = false;
            Destroy(currentLine); 
        }
    }

}
