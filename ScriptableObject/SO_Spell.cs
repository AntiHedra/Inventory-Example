using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Spell", menuName = "Spells/Spell")]
public class SO_Spell : SO_Weapon {

    public SBlankBase activeBlank;
    public SBlankBase blank;
    public float castTime;
}
