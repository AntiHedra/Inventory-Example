using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : MonoBehaviour, IPickUp {

    [SerializeField] private SO_Spell _Spell;

    public void PickUp(GameObject parent) {
        SpellbarController.instance.AddItem(_Spell);
        Destroy(gameObject);
    }
}
