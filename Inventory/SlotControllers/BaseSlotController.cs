using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlotController : MonoBehaviour {

    public ValueController valueController;
    public SO_Item _Item;
    public Blinker blinker;

    [SerializeField]
    public Image itemImage;

    public void Awake() {
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        blinker = transform.GetComponent<Blinker>();
        UpdateInfo();
    }

    public void UpdateInfo() {

        if (_Item) {
            itemImage.sprite = _Item.icon;
            itemImage.gameObject.SetActive(true);

        } else {
            itemImage.sprite = null;
            itemImage.gameObject.SetActive(false);
        }
    }

    public void Blink() {
        blinker.Blink();
    }

    public virtual void TryUse() {

        if (_Item && _Item is SO_Consumable) {
            valueController.ChangeHealth((int)(_Item as SO_Consumable).healthEffect);
            valueController.ChangeMana((int)(_Item as SO_Consumable).manaEffect);
            Blink();
            Remove();
            UpdateInfo();

        } else Blink();
    }

    public void Remove() {
        _Item = null;
        UpdateInfo();
    }
}