using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickUp {

    [SerializeField] private SO_Item _Item;

    public void PickUp(GameObject parent) {
        var player = parent.GetComponent<PlayerController>();
        var npcInventory = parent.GetComponent<NPCInventory>();

        if (player) { 

            if (HotbarController.instance.inventoryFull == false) {
                HotbarController.instance.AddItem(_Item);
                Destroy(gameObject);

            } else if (InventoryController.instance.inventoryFull == false) {
                InventoryController.instance.AddItem(_Item);
                Destroy(gameObject);
            }

        } else if (npcInventory) {

            if (npcInventory.inventoryFull == false) {
                npcInventory.AddItem(_Item);
                Destroy(gameObject);
            }
        }
    }
}
