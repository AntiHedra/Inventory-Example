using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : BaseInventory {

    public GameManager gameManager;

    private bool inventoryOpen;

    public static InventoryController instance;

    public override void Start() {
        instance = this;
        base.Start();

        canvas = transform.Find("InventoryCanvas").GetComponent<Canvas>();
        CloseInventory();
    }

    public void Update() {

        if (Input.GetButtonDown("Inventory")) {

            if (inventoryOpen == false) {
                OpenInventory();

            } else CloseInventory();
        }
    }

    private void OpenInventory() {
        UpdateSlots();
        canvas.gameObject.SetActive(true);
        gameManager.inventoryOpen = true;
        inventoryOpen = true;
    }

    private void CloseInventory() {
        canvas.gameObject.SetActive(false);
        gameManager.inventoryOpen = false;
        inventoryOpen = false;
    }
}
