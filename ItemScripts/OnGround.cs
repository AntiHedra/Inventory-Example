using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OnGround : MonoBehaviour {

    public SO_OnGround _OnGround;

    public void DestroyOnGround() {
        Destroy(gameObject);
    }
}
