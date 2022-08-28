using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform centerPos;
    [SerializeField]
    private float sonarValue;
    [SerializeField]
    private float defaultTimer;

    [Header("For Debug")]
    [SerializeField, Tooltip("For Debug")]
    private float timer; 

    private SimpleSonarShader_Object thisSonar; 

    private void OnEnable()
    {
        thisSonar = GetComponent<SimpleSonarShader_Object>();
        timer = defaultTimer; 
    }

    private void Update()
    {
        timer -= Time.deltaTime; 
        if(timer <= 0)
        {
            TriggerSonar();
            timer = defaultTimer; 
        }
    }

    private void TriggerSonar()
    {
        thisSonar.StartSonarRing(centerPos.position, sonarValue); 
    }

}
