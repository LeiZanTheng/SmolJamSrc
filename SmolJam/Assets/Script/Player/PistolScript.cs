using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float offset;
    [SerializeField]GameObject playerBullet;
    [SerializeField]Transform ShootPoint;
    [SerializeField]float BulletSpeed = 10f;
    [SerializeField]float TimeBtwShots = 0.8f;
    SpriteRenderer WeaponRenderer;
    AudioClip PlayerGunShot;
    AudioSource GunAudioSrc;
    bool AllowShoot = true;
    void Start()
    {
        WeaponRenderer = GetComponent<SpriteRenderer>();
        PlayerGunShot = Resources.Load<AudioClip>("playerGunShot");
        GunAudioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if(Input.GetButton("Fire1") && AllowShoot)
        {
            AllowShoot = false;
            Shoot();
        }
        //flip weapon
        //get the z rotation
        float Rotation = 0f;
        if(transform.eulerAngles.z <= 180f)
        {
            Rotation = transform.eulerAngles.z;
        }
        if(transform.eulerAngles.z > 180f)
        {
            Rotation = transform.eulerAngles.z - 360f;
        }
        //flippin
        if(Rotation >= -90f && Rotation <= 90f)
        {
            WeaponRenderer.flipY = false;
        }
        else
        {
            WeaponRenderer.flipY = true;
        }
    }
    void Shoot()
    {
        GunAudioSrc.PlayOneShot(PlayerGunShot);
        GameObject curBullet = Instantiate(playerBullet, ShootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = curBullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(transform.right * BulletSpeed * Time.fixedDeltaTime * 50f, ForceMode2D.Impulse);
        Invoke(nameof(ResetShoot), TimeBtwShots);
    }
    void ResetShoot()
    {
        AllowShoot = true;
    }
}
