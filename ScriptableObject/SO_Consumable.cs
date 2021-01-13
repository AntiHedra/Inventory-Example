using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumables")]
public class SO_Consumable : SO_Item {
    public float healthEffect;
    public float manaEffect;
    public string buffEffect;
}
