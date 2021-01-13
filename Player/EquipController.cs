using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour {

    public BaseSlotController currentSlot;
    public BaseSlotController lastSlot;

    private WeaponController weaponController;
    private SpellController spellController;
    private ValueController valueController;

    private void Start() {
        weaponController = transform.GetComponent<WeaponController>();
        spellController = transform.GetComponent<SpellController>();
        valueController = transform.parent.GetComponentInChildren<ValueController>();
    }

    public void TryEquip(BaseSlotController slot) {

        if (slot._Item != null) {

            if (slot != currentSlot) {

                if (currentSlot != null) {

                    if (!(currentSlot._Item as SO_Spell)) {
                        lastSlot = currentSlot;
                        (lastSlot as WeaponSlotController).DeSelect();

                    } else (currentSlot as WeaponSlotController).DeSelect();
                }

                EquipWeapon(slot);

            } else UnequipWeapon();

        } else slot.Blink();
    }

    public void EquipWeapon(BaseSlotController slot) {

        if (slot == lastSlot) {
            lastSlot = null;
        }

        (slot as WeaponSlotController).Select();
        currentSlot = slot;

        var spell = currentSlot._Item as SO_Spell;

        if (spell) {
            spellController.currentSpell = spell.activeBlank;
        }
    }

    public void UnequipWeapon() {
        (currentSlot as WeaponSlotController).DeSelect();
        currentSlot = null;

        if (lastSlot != null) {
            EquipWeapon(lastSlot);
        }
    }

    public void TryFire() {
        var weapon = currentSlot._Item as SO_Weapon;

        if (CostCheck() == true) {

            if (weapon as SO_Spell) {
                spellController.TryCast();
                weaponController._Weapon = null;

            } else {
                weaponController._Weapon = weapon;
                weaponController.TryFire();
            }
        }
    }

    public void TryAlt() {
        var weapon = currentSlot._Item as SO_Weapon;

        if (CostCheck() == true) {

            if (weapon as SO_Spell) {
                spellController.TryAlt();

            } else weaponController.Alt();
        }
    }

    private bool CostCheck() {
        var weapon = currentSlot._Item as SO_Weapon;
        var absMana = Mathf.Abs(weapon.manaCost);
        var absHealth = Mathf.Abs(weapon.healthCost);

        if (valueController.manaValue.currentValue >= absMana &&
            valueController.healthValue.currentValue >= absHealth) {

            return true;

        } else return false;
    }

    public void ChangeValues(int multiply) { 
        var weapon = currentSlot._Item as SO_Weapon;

        valueController.ChangeMana(weapon.manaCost * multiply);
        valueController.ChangeHealth(weapon.healthCost * multiply);
    }
}
