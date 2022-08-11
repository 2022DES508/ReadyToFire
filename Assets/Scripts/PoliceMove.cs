using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{

    private int posIndex;
    private float timer;
    private PoliceAttributes PA;

    public bool isStop;

    public GameObject policeUI;

    public Rigidbody rb;
    [SerializeField] 
    private float fixValue;

    private Vector3 lastPos; 

    private void Start()
    {
        posIndex = 0;
        timer = 0;
        PA = GetComponent<PoliceAttributes>();
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Movement();
        ShowPoliceUI(); 
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
            lastPos = transform.position; 
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

                // this.gameObject.transform.position = targetPos;
                /*
                if (Vector3.Distance(targetPos, lastPos) >= 5f)
                {
                    rb.velocity = new Vector3((targetPos.x - lastPos.x) * fixValue, (targetPos.y - lastPos.y) * fixValue, (targetPos.z - lastPos.z) * fixValue); 
                    lastPos = targetPos; 
                    Debug.Log(rb.velocity);
                }
                */

                rb.velocity = new Vector3((targetPos.x - transform.position.x) * fixValue, (targetPos.y - transform.position.y) * fixValue, (targetPos.z - transform.position.z) * fixValue);

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
    }

    void ShowPoliceUI()
    {
        if (GameManager.GM.isShowPoliceUI) 
        {
            policeUI.SetActive(true);
            Time.timeScale = 0f; 
        }
        else
        {
            policeUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
