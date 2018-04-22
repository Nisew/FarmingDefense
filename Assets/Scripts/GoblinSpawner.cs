using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public static GoblinSpawner instance;
    public GameObject smallEnemyPrefab;
    public GameObject mediumEnemyPrefab;
    public GameObject bigEnemyPrefab;
    public Transform leftSpawner;
    public Transform rightSpawner;
    public int wave = 0;
    public int goblins;

    float timeBetweenWaves = 20;
    float counter;
    bool left;

    void Awake()
    {
        instance = this;
    }

	void Update ()
    {
        if(goblins <= 0)
        {
            counter -= Time.deltaTime;

            if(counter <= 0)
            {
                StartCoroutine(SpawnWave());
                counter = timeBetweenWaves + 1.5f;
            }
        }
	}

    IEnumerator SpawnWave()
    {
        wave++;
        if(wave <= 3)
        {
            goblins = Random.Range(2, 4);
        }
        if(wave > 3 && wave <= 9)
        {
            goblins = Random.Range(5, 7);
        }
        if(wave > 9)
        {
            goblins = Random.Range(9, 12);
        }
        if(wave > 15)
        {
            goblins = Random.Range(13, 16);
        }
        left = !left;

        for (int i = 0; i < goblins; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }

    void SpawnEnemy()
    {
        if(left)
        {
            if(wave <= 5)
            {
                int i = Random.Range(0, 100);

                if(i <= 90)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(smallEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(mediumEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
            }
            if(wave > 5 && wave <= 15)
            {
                int i = Random.Range(0, 100);

                if (i <= 70)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(smallEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else if (i <= 90)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(mediumEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(bigEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
            }
            if(wave > 15 && wave <= 20)
            {
                int i = Random.Range(0, 100);

                if (i <= 20)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(smallEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else if (i <= 60)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(mediumEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(bigEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
            }
            if (wave > 20)
            {
                int i = Random.Range(0, 100);

                if (i <= 10)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(smallEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else if (i <= 40)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(mediumEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = true;
                    Instantiate(bigEnemyPrefab, leftSpawner.position, leftSpawner.rotation);
                }
            }

        }
        else
        {
            if (wave <= 5)
            {
                int i = Random.Range(0, 100);

                if (i <= 90)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(smallEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(mediumEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
            }
            if (wave > 5 && wave <= 15)
            {
                int i = Random.Range(0, 100);

                if (i <= 70)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(smallEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else if (i <= 90)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(mediumEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(bigEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
            }
            if (wave > 15 && wave <= 20)
            {
                int i = Random.Range(0, 100);

                if (i <= 20)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(smallEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else if (i <= 60)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(mediumEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(bigEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
            }
            if (wave > 20)
            {
                int i = Random.Range(0, 100);

                if (i <= 10)
                {
                    smallEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(smallEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else if (i <= 40)
                {
                    mediumEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(mediumEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
                else
                {
                    bigEnemyPrefab.GetComponent<Goblin>().left = false;
                    Instantiate(bigEnemyPrefab, rightSpawner.position, rightSpawner.rotation);
                }
            }
        }
    }
}
