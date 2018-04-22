using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    float speed = 10;

	void Start ()
    {
		
	}

	void Update ()
    {
		if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Vector3 dir = target.transform.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if(dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
	}

    public void Seek(GameObject _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        target.GetComponent<Goblin>().Damaged(20);
        Destroy(this.gameObject);
    }
}
