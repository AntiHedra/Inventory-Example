using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFreezable {

    void Freeze(float speedFactor, float time);

    IEnumerator FreezeTimer(float oldSpeed, float time);
}