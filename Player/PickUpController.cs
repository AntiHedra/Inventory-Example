using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    private GameObject parent;

    private void Start() {
        parent = transform.parent.gameObject;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        IPickUp pickUp = other.GetComponent<IPickUp>();
        pickUp?.PickUp(parent);
    }
}
