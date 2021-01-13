using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    public SBlankBase activeSpell;
    public SBlankBase currentSpell;

    public SO_Spell activeCanCombo1;
    public SO_Spell activeCanCombo2;

    private EquipController equipController;
    private UnitSelector unitSelector;

    public bool selecting;

    private void Start() {
        equipController = transform.GetComponent<EquipController>();
        unitSelector = transform.GetComponent<UnitSelector>();
    }

    public void TryCast() {

        if (selecting == false) {

            if (currentSpell as SBlankType2) {
                unitSelector.spell = currentSpell as SBlankType2;
                unitSelector.enabled = true;
                unitSelector.StartSelector();

                activeSpell = currentSpell;

                selecting = true;

            } else {
                equipController.ChangeValues(1);
                Cast();
            }

        } else {
            var hit = unitSelector.SelectUnit();
            equipController.ChangeValues(hit);
        }
    }

    public void TryAlt() {

        if (selecting == true && currentSpell == activeSpell) {
            var selection = unitSelector.GetSelection();

            Cast();
            (currentSpell as SBlankType2).ApplyToUnits(selection);

            unitSelector.Clear();
            unitSelector.spell = null;
            unitSelector.enabled = false;

            selecting = false;
        }

        if (activeSpell) {

            if (currentSpell._Spell == activeCanCombo1) {
                activeSpell.Combo1();
                equipController.ChangeValues(1);
            }

            if (currentSpell._Spell == activeCanCombo2) {
                activeSpell.Combo2();
                equipController.ChangeValues(1);
            }
        }
    }

    public void Cast() {

        SO_Spell combo1, combo2;
        currentSpell.CastSpell(out combo1, out combo2);
        activeCanCombo1 = combo1;
        activeCanCombo2 = combo2;

        activeSpell = currentSpell;
    }
}