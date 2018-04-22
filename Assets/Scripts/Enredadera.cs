using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enredadera : MonoBehaviour
{
    float growing = 0;
    float growingCounter = 60;
    bool catchable;
    public GameObject thornPrefab;
    GameObject target;
    float range = 2.5f;
    float fireCounter;
    float fireRate = 0.4f;
    public bool boosted;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCounter <= 0)
        {
            Shoot();
            fireCounter = 1f / fireRate;
        }

        fireCounter -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemyArray)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && closestDistance <= range)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(thornPrefab, transform.position, transform.rotation);
        ThornBullet bullet = bulletGO.GetComponent<ThornBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    public void Boost()
    {
        fireRate = 1;
        boosted = true;
    }
}
