using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentLiveDectector : MonoBehaviour
{
    Transform president;
    public static bool presidentIsLive = true;
    void Start()
    {
        president = GameObject.FindGameObjectWithTag("President").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(president == null || Citizen.CurrentReputation <= -20f)
        {
            presidentIsLive = false;
        }
        else
        {
            presidentIsLive = true;
        }
    }
}
