using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpellObject {
    void UnPack(SBlankType3 blank, ObjectPool hostPool, GameObject caster, SO_Spell _Spell);
    void Pack();
}
