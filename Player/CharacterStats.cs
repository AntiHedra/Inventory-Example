using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IFreezable {

    public float unitSelectionDistance;
    public float speed, defaultSpeed;

    public void Freeze(float speedFactor, float time) {
        speed = speed * speedFactor;
        StartCoroutine(StatEffect(time));
    }

    public IEnumerator FreezeTimer(float oldSpeed, float time) {
        throw new System.NotImplementedException();
    }

    IEnumerator StatEffect(float duration) {
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }
}