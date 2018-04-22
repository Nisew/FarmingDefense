using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    float speed;
    public float live = 100;
    public bool small;
    public bool medium;
    public bool big;
    float slowCounter;
    bool slowed;

    Transform target;
    public bool left;
    int wavePointIndex;

    void Start()
    {
        if(left)
        {
            target = Waypoints.leftPoints[0];
        }
        else
        {
            target = Waypoints.rightPoints[0];
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if(small)
        {
            speed = Random.Range(1, 2);

            if(GoblinSpawner.instance.wave > 5 && GoblinSpawner.instance.wave <= 10)
            {
                live *= 1.5f;
            }
            if (GoblinSpawner.instance.wave > 10 && GoblinSpawner.instance.wave <= 15)
            {
                live *= 2f;
            }
            if (GoblinSpawner.instance.wave > 15 && GoblinSpawner.instance.wave <= 20)
            {
                live *= 2.5f;
            }
            if (GoblinSpawner.instance.wave > 20)
            {
                live *= 4f;
            }
        }
        if (medium)
        {
            speed = Random.Range(0.8f, 1);

            if (GoblinSpawner.instance.wave > 5 && GoblinSpawner.instance.wave <= 10)
            {
                live *= 1.5f;
            }
            if (GoblinSpawner.instance.wave > 10 && GoblinSpawner.instance.wave <= 15)
            {
                live *= 2f;
            }
            if (GoblinSpawner.instance.wave > 15 && GoblinSpawner.instance.wave <= 20)
            {
                live *= 2.5f;
            }
            if (GoblinSpawner.instance.wave > 20)
            {
                live *= 4f;
            }
        }
        if (big)
        {
            speed = Random.Range(0.6f, 0.8f);

            if (GoblinSpawner.instance.wave > 5 && GoblinSpawner.instance.wave <= 10)
            {
                live *= 1.5f;
            }
            if (GoblinSpawner.instance.wave > 10 && GoblinSpawner.instance.wave <= 15)
            {
                live *= 2f;
            }
            if (GoblinSpawner.instance.wave > 15 && GoblinSpawner.instance.wave <= 20)
            {
                live *= 2.5f;
            }
            if (GoblinSpawner.instance.wave > 20)
            {
                live *= 4f;
            }
        }
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            NextWayPoint();
        }

        if(slowed)
        {
            slowCounter -= Time.deltaTime;
            if(slowCounter <= 0)
            {
                slowed = false;
                speed = speed * 2;
            }
        }
    }

    void NextWayPoint()
    {
        if(left)
        {
            if(wavePointIndex >= Waypoints.leftPoints.Length - 1)
            {
                Resources.instance.lives--;
                GoblinSpawner.instance.goblins--;
                Resources.instance.ActualizeLives();
                PlaySound.instance.Play(8, 0.5f, 0.5f);
                Destroy(this.gameObject);
                return;
            }
        }
        else
        {
            if (wavePointIndex >= Waypoints.rightPoints.Length - 1)
            {
                Resources.instance.lives--;
                GoblinSpawner.instance.goblins--;
                Resources.instance.ActualizeLives();
                PlaySound.instance.Play(8, 0.5f, 0.5f);
                Destroy(this.gameObject);
                return;
            }
        }

        wavePointIndex++;

        if(left)
        {
            target = Waypoints.leftPoints[wavePointIndex];
        }
        else
        {
            target = Waypoints.rightPoints[wavePointIndex];
        }
    }

    public void Damaged(int damage)
    {
        live -= damage;
        PlaySound.instance.Play(4, 0.2f, 1);

        if (live <= 0)
        {
            GoblinSpawner.instance.goblins--;

            if (small)
            {
                Resources.instance.score += 1;
                PlaySound.instance.Play(9, 0.4f, 2);
                Resources.instance.ActualizeScore();
            }
            if (medium)
            {
                Resources.instance.score += 3;
                PlaySound.instance.Play(9, 0.4f, 1);
                Resources.instance.ActualizeScore();
            }
            if (big)
            {
                Resources.instance.score += 5;
                PlaySound.instance.Play(9, 0.4f, 0.5f);
                Resources.instance.ActualizeScore();
            }
            Destroy(this.gameObject);
        }
    }

    public void Slow()
    {
        if(!slowed)
        {
            slowed = true;
            speed = speed * 0.7f;
            slowCounter = 1.5f;
        }
    }
}
