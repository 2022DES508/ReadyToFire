using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; 
    [SerializeField]
    private int adjustValue;

    [SerializeField]
    private float minHeight;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float minLength;
    [SerializeField]
    private float maxLength; 

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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minLength, maxLength), transform.position.y, Mathf.Clamp(transform.position.z, minHeight, maxHeight)); 
    }
}
