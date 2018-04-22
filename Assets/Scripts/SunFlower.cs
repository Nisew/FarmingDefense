using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    float growing = 20;
    float counter = 30;
    float counterAlpha = 20;
    public Sprite jovensuelo;
    public Sprite madurito;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(growing >= 0)
        {
            growing -= Time.deltaTime;

		    if(growing <= 10)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = jovensuelo;
            }

            if (growing <= 0)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = madurito;
            }
        }
        else
        {
            counter -= Time.deltaTime;

            if(counter <= 0)
            {
                counter = counterAlpha;
                Resources.instance.energy += 5;
                Resources.instance.ActualizeEnergy();
            }
        }
    }

    public void Boost()
    {
        counterAlpha = 15;
    }
}
