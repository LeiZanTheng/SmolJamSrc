using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitching : MonoBehaviour
{
    public static bool IsUsingShield;
    [SerializeField]float timeBtwSwitching;
    [SerializeField] Transform[] Weapons;
    int SelectedWeapon;
    bool AllowSwitch = true;
    private void Start() {
        SelectedWeapon = 0;
        SetWeapons();
        Select(SelectedWeapon);
    }
    private void Update() {
        if(AllowSwitch)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0f )
            {
                SelectedWeapon++;
                if(SelectedWeapon > Weapons.Length - 1)
                {
                    SelectedWeapon = 0;
                }
                Select(SelectedWeapon);
                AllowSwitch = false;
                Invoke(nameof(ResetSwitch), timeBtwSwitching);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                SelectedWeapon--;
                if(SelectedWeapon < 0)
                {
                    SelectedWeapon = Weapons.Length - 1;
                }
                Select(SelectedWeapon);
                AllowSwitch = false;
                Invoke(nameof(ResetSwitch), timeBtwSwitching);
            }
        }
    }
    void SetWeapons()
    {
        Weapons = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Weapons[i] = transform.GetChild(i);
        }
    }
    void Select(int WeaponIndex)
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].gameObject.SetActive(i == WeaponIndex);
        }
    }
    void ResetSwitch()
    {
        AllowSwitch = true;
    }
}
