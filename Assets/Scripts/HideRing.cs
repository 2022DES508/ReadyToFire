using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRing : MonoBehaviour
{
    private MeshRenderer mr;
    [SerializeField] 
    private float hideValue;

    private void OnEnable()
    {
        mr = GetComponent<MeshRenderer>(); 
    }
    void Update()
    {
        FindCops(); 
    }

    void HideMe()
    {
        mr.enabled = false; 
    }
    void ShowMe()
    {
        mr.enabled = true; 
    }

    void FindCops()
    {
        bool isShow = false;
        PoliceAttributes[] allcops = FindObjectsOfType<PoliceAttributes>();
        foreach (var cop in allcops)
        {
            if (Vector3.Distance(transform.position, cop.transform.position) <= hideValue)
            {
                isShow = true; 
            }
        }
        if (isShow)
        {
            ShowMe(); 
        }
        else
        {
            HideMe(); 
        }
    }
}
