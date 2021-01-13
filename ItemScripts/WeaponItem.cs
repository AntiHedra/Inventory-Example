using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IPickUp, IPushable {

    [SerializeField] private SO_Weapon _Weapon;

    public void PickUp(GameObject parent) {
        var player = parent.GetComponent<PlayerController>();

        if (player) {
            HotbarController.instance.AddWeapons(_Weapon);
            Destroy(gameObject);

        } else {
            var npcInventory = parent.GetComponent<NPCInventory>();
            npcInventory.AddWeapon(_Weapon);
            Destroy(gameObject);
        }
    }
}