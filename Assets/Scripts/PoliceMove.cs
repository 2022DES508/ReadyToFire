using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{

    private int posIndex;
    private float timer;
    private PoliceAttributes PA;

    private bool isStop; 

    private void Start()
    {
        posIndex = 0;
        timer = 0;
        PA = GetComponent<PoliceAttributes>(); 
    }

    void Update()
    {
        Movement(); 
    }

    void Movement()
    {
        if (isStop)
        {
            PA.path.Clear();
            isStop = false;
            return; 
        } 

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
                /*
                int num = 2; 
                if (posIndex < PA.path.ToArray().Length - num && posIndex % num == 0)
                {
                    Vector3 lookPos = new Vector3(PA.path[posIndex + num].x, 
                        (float)(PA.path[posIndex + num].y + 0.75f), PA.path[posIndex + num].z); 
                    this.gameObject.transform.LookAt(lookPos); 
                }
                */
                Vector3 targetPos = new Vector3(PA.path[posIndex].x,
                    (float)(PA.path[posIndex].y + 0.75f), PA.path[posIndex].z);

                this.gameObject.transform.position = targetPos;
                /*
                if (posIndex == PA.path.ToArray().Length - 1)
                    this.gameObject.transform.LookAt(targetPos); 
                */
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


    private void OnTriggerEnter(Collider other)
    {
        isStop = true;
        PA.endMove = true;

        if (other.tag == "BlueDoor")
        {

        }
    }

}
