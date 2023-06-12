using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatrolPointPos : MonoBehaviour
{
    public static Transform[] PatrolPoints;    
    private void Awake() {
        PatrolPoints = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            PatrolPoints[i] = transform.GetChild(i);
        }
    }
}
