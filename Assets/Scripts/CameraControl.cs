using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; 
    [SerializeField]
    private int adjustValue;

    private void Update()
    {
        MoveCamera(); 
    }

    void MoveCamera()
    {
        if (Input.mousePosition.x <= adjustValue)
        {
            transform.Translate(translation: Time.deltaTime * moveSpeed * transform.right); 
        }
        else if (Input.mousePosition.x >= Screen.width - adjustValue)
        {
            transform.Translate(translation: Time.deltaTime * moveSpeed * -transform.right); 
        }

        if (Input.mousePosition.y <= adjustValue)
        {
            transform.Translate(translation: Time.deltaTime * moveSpeed * transform.forward);
        }
        else if (Input.mousePosition.y >= Screen.height - adjustValue)
        {
            transform.Translate(translation: Time.deltaTime * moveSpeed * -transform.forward); 
        }
    }
}
