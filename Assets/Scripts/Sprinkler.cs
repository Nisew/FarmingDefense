using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    float range = 1.5f;
    float counter = 20;
	
	void Start ()
    {
        InvokeRepeating("UpdateBoosteds", 0, 5f);

    }

    void UpdateBoosteds()
    {
        List<GameObject> turretArray = new List<GameObject>();

        foreach(GameObject trigo in GameObject.FindGameObjectsWithTag("Trigo"))
        {
            turretArray.Add(trigo);
        }
        foreach (GameObject enredadera in GameObject.FindGameObjectsWithTag("Enredadera"))
        {
            turretArray.Add(enredadera);
        }
        foreach (GameObject sunflower in GameObject.FindGameObjectsWithTag("SunFlower"))
        {
            turretArray.Add(sunflower);
        }

        GameObject nearestTurret = null;

        foreach (GameObject turret in turretArray)
        {
            float distanceToTurret = Vector2.Distance(transform.position, turret.transform.position);
            if (distanceToTurret <= 1 && distanceToTurret > 0.5f)
            {
                nearestTurret = turret;

                if (nearestTurret.tag == "Enredadera")
                {
                    Debug.Log("enredadera boosted");
                    nearestTurret.GetComponent<Enredadera>().Boost();
                }
                if (nearestTurret.tag == "Trigo")
                {
                    nearestTurret.GetComponent<Wheat>().Boost();
                }
                if (nearestTurret.tag == "SunFlower")
                {
                    nearestTurret.GetComponent<SunFlower>().Boost();
                }                
            }
        }
    }
}
