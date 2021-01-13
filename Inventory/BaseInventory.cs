using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventory : MonoBehaviour {

    public Canvas canvas;
    public bool inventoryFull;

    public List<SO_Item> itemsList = new List<SO_Item>();
    public List<BaseSlotController> slotsList = new List<BaseSlotController>();

    public virtual void Start() {
        UpdateSlots();
    }

    public virtual void UpdateSlots() {

        for (int i = 0; i < slotsList.Count; i++) {
            slotsList[i]._Item = itemsList[i];
            slotsList[i].UpdateInfo();
        }
    }

    public virtual void AddItem(SO_Item _Item) {

        for (int n = 0; n < itemsList.Count; n++) {

            if (itemsList[n] == null) {
                itemsList[n] = _Item;
                UpdateSlots();

                if (!itemsList.Contains(null)) {
                    inventoryFull = true;
                }

                break;
            }
        }
    }

    public virtual void RemoveItems(SO_Item _Item) {
        itemsList.Remove(_Item);
        UpdateSlots();

        if (inventoryFull == true && itemsList.Contains(null)) {
            inventoryFull = false;
        }
    }
}