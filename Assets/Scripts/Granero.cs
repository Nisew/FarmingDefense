using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granero : MonoBehaviour
{
    public Sprite graneroDestruido;

	void Update ()
    {
		if(Resources.instance.lives == 1)
        {
            GetComponent<SpriteRenderer>().sprite = graneroDestruido;
        }
	}
}
