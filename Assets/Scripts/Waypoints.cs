using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public bool left;
    public static Transform[] leftPoints;
    public static Transform[] rightPoints;

    void Awake()
    {
        if(left)
        {
            leftPoints = new Transform[transform.childCount];
            for (int i = 0; i < leftPoints.Length; i++)
            {
                leftPoints[i] = transform.GetChild(i);
            }
        }
        else
        {
            rightPoints = new Transform[transform.childCount];
            for (int i = 0; i < rightPoints.Length; i++)
            {
                rightPoints[i] = transform.GetChild(i);
            }
        }
    }
}
