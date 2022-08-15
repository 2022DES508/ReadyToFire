using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField]
    private float throwForce;

    private Vector3 beginDirection;

    private Rigidbody rb;

    private Vector3 smokePos;

    private MeshRenderer mr;
    private ParticleSystem FXps; 

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        mr = GetComponent<MeshRenderer>();
        FXps = GetComponentInChildren<ParticleSystem>(); 
    }

    private void Start()
    {
        // SetDirection(transform.forward * 10); 
        rb.velocity = beginDirection;
        FXps.Pause(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            smokePos = transform.position;
            rb.isKinematic = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            mr.enabled = false;
            FXps.Play(); 

            StartCoroutine(coroutine_BombAnimation());
        }
    }

    IEnumerator coroutine_BombAnimation()
    {
        yield return StartCoroutine(coroutine_Smoke(10f)); 
        Destroy(gameObject);
    }

    IEnumerator coroutine_Smoke(float timer)
    {
        StartCoroutine("SmokeChange");
        yield return new WaitForSeconds(timer);
    }

    IEnumerator SmokeChange() 
    {
        while (true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(5f, 5f, 5f), Time.deltaTime);
            yield return null;
        }
    }

    public void SetDirection(Vector3 curForward)
    {
        float fixValue = 2;
        beginDirection = new Vector3(curForward.x * fixValue, throwForce, curForward.z * fixValue);
    }
}
