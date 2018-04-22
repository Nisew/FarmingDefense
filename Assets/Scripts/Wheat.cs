using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    float growing = 20;
    float growingTime = 30;
    public bool maduro;
    public Sprite jovensuelo;
    public Sprite madurito;

    void Start()
    {

    }

    void Update()
    {
        if (growing >= 0)
        {
            growing -= Time.deltaTime;

            if (growing <= 10)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = jovensuelo;
            }

            if (growing <= 3)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = madurito;
            }
            if(growing <= 0)
            {
                Collected();
            }
        }

    }

    public void Collected()
    {
        growing = growingTime;
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = jovensuelo;
        Resources.instance.money += 8;
        Resources.instance.ActualizeMoney();
    }

    public void Boost()
    {
        growingTime = 25;
    }
}
