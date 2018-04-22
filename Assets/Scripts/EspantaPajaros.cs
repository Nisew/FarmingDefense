using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspantaPajaros : MonoBehaviour
{
    float damage;
    public float range;
    GameObject target;
    public GameObject bulletPrefab;
    public GameObject firepoint;

    float fireRate = 0.7f;
    float fireCounter;

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
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
	
	void Update ()
    {
        if(target == null)
        {
            return;
        }

        if(fireCounter <= 0)
        {
            Shoot();
            fireCounter = 1f / fireRate;
        }

        fireCounter -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.transform.position, transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

}
