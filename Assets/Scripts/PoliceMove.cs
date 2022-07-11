using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{

    private int posIndex;
    private float timer;
    private PoliceAttributes PA;

    private void Start()
    {
        posIndex = 0;
        timer = 0;
        PA = GetComponent<PoliceAttributes>(); 
    }

    void Update()
    {
        if (PA.startMove)
        {
            PA.startMove = false; 
            posIndex = 1; 
        }

        if (timer > 1 / PA.moveSpeed)
        {
            timer = 0; 
            if (posIndex > 0 && posIndex < PA.path.ToArray().Length)
            {
                this.gameObject.transform.position = new Vector3(PA.path[posIndex].x,
                    (float)(PA.path[posIndex].y + 0.75f) , PA.path[posIndex].z); 
                posIndex += 1;
            }
            else
            {
                posIndex = 0;
                PA.endMove = true; 
            }
        }
        else
        {
            timer += Time.deltaTime; 
        }
    }
}
