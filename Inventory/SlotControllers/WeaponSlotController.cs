using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotController : BaseSlotController {

    public void Select() {
        blinker.Select();
    }

    public void DeSelect() {
        blinker.DeSelect();
    }

    public override void TryUse() {
    }
}