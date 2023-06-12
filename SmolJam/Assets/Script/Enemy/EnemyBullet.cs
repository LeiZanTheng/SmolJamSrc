using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]float LifeTime = 1.5f;
    [SerializeField]bool isSniperBullet;
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
        if(other.CompareTag("Player") || other.CompareTag("President"))
        {
            BulletSrc.PlayOneShot(dedSound);
            Destroy(other.gameObject, 0.005f);
            Destroy(gameObject);
        }
        if(!other.CompareTag("InvisibleCollider") && !other.CompareTag("Enemy") && !other.CompareTag("Citizen"))
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("Shield") && isSniperBullet)
        {
            other.gameObject.GetComponent<Shield>().isDisabled = true;
            Destroy(gameObject);
        }
    }
}
