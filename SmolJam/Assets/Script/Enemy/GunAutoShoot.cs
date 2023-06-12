using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAutoShoot : MonoBehaviour
{
    Transform Target;
    [SerializeField]GameObject EnemyBullet;
    [SerializeField]float EnemyShootingRate = 1f;
    [SerializeField]float EnemyShootingForce = 500f;
    Transform ShootingPoint;
    bool AllowShoot = true;
    SpriteRenderer WeaponRenderer;
    AudioSource GunAudioSrc;
    AudioClip Ak47Shot;
    private void Start() {
        Target = GameObject.FindGameObjectWithTag("President").GetComponent<Transform>();
        WeaponRenderer = GetComponent<SpriteRenderer>();
        ShootingPoint = transform.GetChild(0).GetComponent<Transform>();
        GunAudioSrc = GetComponent<AudioSource>();
        Ak47Shot = Resources.Load<AudioClip>("Ak47GunShot");
    }
    private void Update() {
        //rotate weapon towards player
        Vector3 difference = Target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        if(rotZ >= -90f && rotZ <= 90f)
        {
            WeaponRenderer.flipY = false;
        }
        else
        {
            WeaponRenderer.flipY = true;
        }
    }
    public void Fire()
    {
        if(AllowShoot)
        {
            GunAudioSrc.PlayOneShot(Ak47Shot);
            AllowShoot = false;
            GameObject curBullet = Instantiate(EnemyBullet, ShootingPoint.position, Quaternion.identity);
            curBullet.GetComponent<Rigidbody2D>().AddForce(ShootingPoint.right * EnemyShootingForce * Time.fixedDeltaTime * 50f, ForceMode2D.Impulse);
            Invoke(nameof(ResetFire), EnemyShootingRate);
        }
    }
    void ResetFire()
    {
        AllowShoot = true;
    }
}
