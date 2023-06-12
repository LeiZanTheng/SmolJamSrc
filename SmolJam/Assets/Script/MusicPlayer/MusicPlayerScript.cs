using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    private void Start() {
        gameObject.GetComponent<AudioSource>().playOnAwake = true;
    }
    public void StopPlayingMusic()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
