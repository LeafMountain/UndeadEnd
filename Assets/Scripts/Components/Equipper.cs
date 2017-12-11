using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Equipper:MonoBehaviour {

    public Inventory inventory; 
    public StringReference playerSuffix;    
    public ColorVariable playerColor;

    [Header("Inventory Slots")]
    public Transform slot1; 
    public Transform slot2;

    List < GameObject > currentlyEquipped = new List < GameObject > (); 

    void OnEnable() {
        if ( ! slot1) {
            slot1 = transform; 
        }

        Refresh(); 
    }

    public void Refresh() {
        Equip(); 
    }

    void Equip() {
        foreach (GameObject go in currentlyEquipped) {
            Destroy(go); 
        }

        currentlyEquipped.Clear(); 

        for (int i = 0; i < inventory.items.Count; i++) {
            GameObject go = Instantiate(inventory.items[i].prefab); 
            currentlyEquipped.Add(go);
            Transform slot;

            if(i == 0){
                slot = slot1;
                DrawLine line = go.GetComponent <DrawLine> ();
                InputMapper input = go.GetComponent<InputMapper>();

                if (line) {
                    line.color = playerColor;
                }
                
                if(input && playerSuffix != null){
                    input.SetSuffix(playerSuffix.Value);
                }

            } else {
                slot = slot2;
            }

            go.transform.SetParent(slot); 
            go.transform.position = slot.position; 
            go.transform.rotation = slot.rotation; 
        }
    }

    public void UseEquipment() {
        TriggerInteract trigger = currentlyEquipped[0].GetComponent <TriggerInteract>(); 

        if (trigger) {
            trigger.Interact(); 
        }
    }
}
