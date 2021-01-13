using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public SO_Weapon _Weapon;

    private GameObject firePoint;
    private EquipController equipController;

    private void Start() {
        firePoint = transform.Find("FirePoint").gameObject;
        equipController = transform.GetComponent<EquipController>();
    }

    public void TryFire() {
        Instantiate(_Weapon.firePrefab);
    }

    public void Alt() { 
    }
}
