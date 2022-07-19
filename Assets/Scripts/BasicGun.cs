using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public float interval;

    public GameObject bulletPrefab;
    // public GameObject shellPrefab; 

    private Transform muzzlePos;
    // private Transform shellPos;

    private Vector3 direction;

    private float timer;

    private void Start()
    {
        muzzlePos = transform.Find("Muzzle");
        // shellPos = transform.Find("BulletShell"); 
    }
    private void Update()
    {
        Shoot(); 
    }

    void Shoot()
    {
        Aiming(); 

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0; 
        }

        if (timer == 0)
        {
            Fire();
            timer = interval;
        }

    }

    void Aiming()
    {
        TerroristAttributes[] enemies = FindObjectsOfType<TerroristAttributes>();
        TerroristAttributes firstEnemy = FindFirstEnemy(enemies, this.transform);
        if (firstEnemy)
        {
            direction = (new Vector3(firstEnemy.transform.position.x, firstEnemy.transform.position.y, firstEnemy.transform.position.z)
                - new Vector3(transform.position.x, transform.position.y, transform.position.z)).normalized;
            // Debug.Log("Aiming direction: " + direction); 
        }
        else
        {
            transform.parent.gameObject.transform.parent.GetComponent<PoliceAttributes>().isFire = false; 
        }
    }

    TerroristAttributes FindFirstEnemy(TerroristAttributes[] enemies, Transform policePos)
    {
        if (enemies.Length <= 0) return null; 
        float minDistance = Vector3.Distance(enemies[0].transform.position, policePos.position);
        TerroristAttributes finalEnemy = enemies[0];

        for (int i = 0; i < enemies.Length; i++)
        {
            float nextDistance = Vector3.Distance(enemies[i].transform.position, policePos.position); 
            if (nextDistance < minDistance)
            {
                finalEnemy = enemies[i];
                minDistance = nextDistance; 
            }
        }

        return finalEnemy; 
    }

    void Fire()
    {
        if (!transform.parent.gameObject.transform.parent.GetComponent<PoliceAttributes>().isFire) return;  

        GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetSpeed(direction); 
    }
}
