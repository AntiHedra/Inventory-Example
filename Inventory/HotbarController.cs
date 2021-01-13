using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : BaseInventory {

    public bool weaponsFull, hotbarBlock;
    public EquipController equipController;

    public List<SO_Weapon> weaponsList = new List<SO_Weapon>();
    public List<WeaponSlotController> weaponSlots = new List<WeaponSlotController>();


    public static HotbarController instance;

    public override void Start() {
        instance = this;
        base.Start();

        canvas = transform.Find("HotbarCanvas").GetComponent<Canvas>();
    }

    public override void UpdateSlots() {
        base.UpdateSlots();

        for (int a = 0; a < weaponSlots.Count; a++) {
            weaponSlots[a]._Item = weaponsList[a];
            weaponSlots[a].UpdateInfo();
        }
    }
    
    public void AddWeapons(SO_Weapon _Weapon) {

        for (int n = 0; n < 3; n++) {

            if (weaponsList[n] == null) {
                weaponsList[n] = _Weapon;
                UpdateSlots();

                if (!itemsList.Contains(null)) {
                    weaponsFull = true;
                }

                break;
            }
        }
    }

    public void RemoveWeapons(SO_Weapon _Weapon) {
        weaponsList.Remove(_Weapon);
        UpdateSlots();

        if (weaponsFull == true && weaponsList.Contains(null)) {
            weaponsFull = false;
        }
    }
}