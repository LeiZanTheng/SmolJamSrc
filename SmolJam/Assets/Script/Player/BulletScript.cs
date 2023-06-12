using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]float LifeTime = 1.5f;
    [SerializeField] GameObject DedParticle;
    AudioSource BulletSrc;
    AudioClip dedSound;
    void Start()
    {
        Destroy(gameObject, LifeTime);
        BulletSrc = GetComponent<AudioSource>();
        dedSound = Resources.Load<AudioClip>("dedSound");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject, 0.005f);
            Instantiate(DedParticle, other.transform.position, Quaternion.identity);
            BulletSrc.PlayOneShot(dedSound);
            Destroy(gameObject);
        }
        if(!other.CompareTag("InvisibleCollider") && (!other.CompareTag("Player") && !other.CompareTag("President")))
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("Citizen"))
        {
            other.GetComponent<Citizen>().Die();
            Instantiate(DedParticle, other.transform.position, Quaternion.identity);
            BulletSrc.PlayOneShot(dedSound);
            Destroy(other.gameObject, 0.005f);
        }
    }
}
