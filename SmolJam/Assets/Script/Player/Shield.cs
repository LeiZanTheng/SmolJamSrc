using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float offset;
    [SerializeField]float CoolDownSpeed;
    [HideInInspector]public bool isDisabled = false;
    bool startCoolingDown = false;
    SpriteRenderer shieldRenderer;
    PolygonCollider2D ShieldCollider;
    AudioSource ShieldSoundSrc;
    AudioClip ShieldBreak;
    private void Start() {
        shieldRenderer = GetComponent<SpriteRenderer>();
        ShieldCollider = GetComponent<PolygonCollider2D>();
        ShieldSoundSrc = GetComponent<AudioSource>();
        ShieldBreak = Resources.Load<AudioClip>("shieldBreak");
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if(isDisabled && !startCoolingDown)
        {
            ShieldSoundSrc.PlayOneShot(ShieldBreak);
            startCoolingDown = true;
            ShieldCollider.enabled = false;
            Invoke(nameof(CoolingDown), CoolDownSpeed);
        }
    }
    public void CoolingDown()
    {
        isDisabled = false;
        startCoolingDown = false;
        ShieldCollider.enabled = true;
    }
}
