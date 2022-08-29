using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float throwForce;

    private Vector3 beginDirection;

    private Rigidbody rb;

    private Vector3 bombPos;
    [SerializeField] 
    private float damageRadius;
    [SerializeField]
    private float damageValue; 

    private ParticleSystem FXps;

    private MeshRenderer mr;

    public GameObject bombObj; 

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        mr = GetComponent<MeshRenderer>(); 
        FXps = GetComponentInChildren<ParticleSystem>(); 
    }

    private void Start()
    {
        // SetDirection(transform.up * 10); 
        rb.velocity = beginDirection;

        // Debug.Log(rb.velocity); 

        FXps.Pause();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            bombPos = transform.position;
            rb.isKinematic = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            mr.enabled = false;
            bombObj.SetActive(false); 
            FXps.Play(); 

            DamageEnemies(damageRadius);  
            StartCoroutine(coroutine_BombAnimation()); 
        }
    }

    void DamageEnemies(float radius)
    {
        float distanceToEnemy;
        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>(); 
        if (enemies != null && enemies.Length !=0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                distanceToEnemy = (enemies[i].gameObject.transform.position - bombPos).magnitude; 
                if (distanceToEnemy <= radius)
                {
                    enemies[i].healthyNow -= damageValue;  
                }
            }
        }
    }

    IEnumerator coroutine_BombAnimation() 
    {
        yield return StartCoroutine(coroutine_Bomb(0.2f));
        Destroy(gameObject);
    }

    IEnumerator coroutine_Bomb(float timer)
    {
        StartCoroutine("Bomb"); 
        yield return new WaitForSeconds(timer); 
    }

    IEnumerator Bomb()
    {
        while (true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(10f, 0.1f, 10f), Time.deltaTime * 10); 
            yield return null; 
        }
    }

    public void SetDirection(Vector3 curForward)
    {
        float fixValue = 1; 
        beginDirection = new Vector3(curForward.x * fixValue, throwForce, curForward.z * fixValue);
        Debug.Log(beginDirection); 
    }
}
