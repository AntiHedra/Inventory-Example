using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbarController : BaseInventory {

    public bool spellbarClosed;
    public SpellController spellController;

    public List<WeaponSlotController> spellSlotsList = new List<WeaponSlotController>();
    public List<SO_Spell> spellsList = new List<SO_Spell>();

    [SerializeField] private GameObject spellBlanksParent;
    [SerializeField] private List<int> slotOpenPos = new List<int>();

    private SO_Spell tempSpell;

    public static SpellbarController instance;

    public override void Start() {
        instance = this;
        base.UpdateSlots();

        slotOpenPos.Add(172);
        slotOpenPos.Add(67);
        slotOpenPos.Add(88);
        slotOpenPos.Add(109);
        slotOpenPos.Add(130);
        slotOpenPos.Add(151);

        canvas = transform.Find("SpellbarCanvas").GetComponent<Canvas>();
    }

    public void Update() {

        if (spellSlotsList[5].transform.localPosition.x != 172) {
            spellbarClosed = false;

        } else spellbarClosed = true;
    }

    public void SwitchSpell(int index) {
        spellSlotsList[index].Blink();

        if (spellsList[index] != null) {
            tempSpell = spellsList[0];
            spellsList[0] = spellsList[index];
            spellsList[index] = tempSpell;

            spellController.currentSpell = spellsList[0].activeBlank;

            UpdateSlots();
        }
    }

    public override void UpdateSlots() {

        for (int i = 0; i < spellSlotsList.Count; i++) {
            spellSlotsList[i]._Item = spellsList[i];
            spellSlotsList[i].UpdateInfo();
        }
    }

    public override void AddItem(SO_Item _Item) {

        for (int n = 0; n < spellSlotsList.Count; n++) {

            if (spellsList[n] == null) {
                spellsList[n] = _Item as SO_Spell;

                var blank = Instantiate((_Item as SO_Spell).blank, spellBlanksParent.transform);
                (_Item as SO_Spell).activeBlank = blank;

                UpdateSlots();

                if (!spellsList.Contains(null)) {
                    inventoryFull = true;
                }

                break;
            }
        }
    }

    public override void RemoveItems(SO_Item _Item) {
        spellsList.Remove(_Item as SO_Spell);
        UpdateSlots();

        if (inventoryFull == true && spellsList.Contains(null)) {
            inventoryFull = false;
        }
    }

    public void OpenSpellbar() {
        HotbarController.instance.hotbarBlock = true;

        for (int i = 1; i < spellSlotsList.Count; i++) {
            LeanTween.cancel(spellSlotsList[i].gameObject);
        }

        for (int i = 1; i < spellSlotsList.Count; i++) {
            spellSlotsList[i].gameObject.SetActive(true);
            LeanTween.moveLocalX(spellSlotsList[i].gameObject, slotOpenPos[i], 0.35f);
        }
    }

    public void CloseSpellbar() {
        HotbarController.instance.hotbarBlock = false;

        for (int i = 1; i < spellSlotsList.Count; i++) {
            LeanTween.cancel(spellSlotsList[i].gameObject);
        }

        for (int i = 1; i < spellSlotsList.Count; i++) {
            LeanTween.moveLocalX(spellSlotsList[i].gameObject, 172, 0.2f);
        }
    }

    public void NoSpellsMessage() {
        Debug.Log("No Spells");
    }
}