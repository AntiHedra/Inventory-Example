using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour {

    public bool inventoryFull;

    public SO_Weapon _Weapon;
    public List<SO_Spell> spellsList = new List<SO_Spell>();
    public List<SO_Item> itemsList = new List<SO_Item>();

    private NPCController npcController;

    private void Start() {
        npcController = transform.GetComponent<NPCController>();
    }

    public void AddItem(SO_Item _Item) {

        for (int i = 0; i < itemsList.Count; i++) {

            if (itemsList[i] == null) {
                itemsList[i] = _Item;

                if (!itemsList.Contains(null)) {
                    inventoryFull = true;
                }

                break;
            }
        }
    }

    public void AddWeapon(SO_Weapon _Weapon) {

        if (this._Weapon != null) {
            RemoveWeapon();
        }

        this._Weapon = _Weapon;

        GetBestSpell(out SO_Spell spell, out float spellRatio);
        npcController.CalculatePower(_Weapon, spell, spellRatio);
    }

    private void RemoveWeapon() {
        Instantiate(_Weapon.prefab, transform.position, Quaternion.identity);
    }

    private void GetBestSpell(out SO_Spell _Spell, out float spellRatio) {
        float bestSpellRatio = 0;
        SO_Spell bestSpell = null;

        for (int i = 0; i < spellsList.Count; i++) {
            float thisSpellRatio = spellsList[i].healthDamage + spellsList[i].manaDamage /
                spellsList[i].healthCost + spellsList[i].manaCost;

            if (thisSpellRatio > bestSpellRatio) {
                bestSpellRatio = thisSpellRatio;
                bestSpell = spellsList[i];
            }
        }

        _Spell = bestSpell;
        spellRatio = bestSpellRatio;
    }
}
