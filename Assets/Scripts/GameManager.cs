using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public bool isDraw;

    public PoliceAttributes currentPA;
    public GameObject currentLine;

    public int enemyCounter; 

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

        CalculateEnemyAmount(); 
    }

    void CalculateEnemyAmount() 
    {
        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>(); 
        if (enemies != null)
        {
            enemyCounter = enemies.Length; 
        }
        else
        {
            enemyCounter = 0; 
        }
    }

}
