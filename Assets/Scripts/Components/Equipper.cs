using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Equipper:MonoBehaviour {

    public Inventory inventory; 
    public StringReference playerSuffix;    
    public ColorVariable playerColor;

    [Header("Inventory Slots")]
    public Transform[] slots;

    List <GameObject> currentlyEquipped = new List < GameObject > (); 

    void OnEnable() {
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

        for (int i = 0; i < slots.Length; i++) {

            if(inventory.items.Count > i){
                GameObject go = Instantiate(inventory.items[i].prefab);
                currentlyEquipped.Add(go);
                Transform slot = slots[i];
                InputMapper input = go.GetComponent<InputMapper>();
                

                if(i == 0){
                    DrawLine line = go.GetComponent <DrawLine>();

                    if (line) {
                        line.color = playerColor;
                    }
                    
                    if(input && playerSuffix != null){
                        input.SetSuffix(playerSuffix.Value);
                    }
                } else {
                    if(input){
                        input.enabled = false;
                    }
                }

                go.transform.SetParent(slot); 
                go.transform.position = slot.position; 
                go.transform.rotation = slot.rotation; 
            }
            
        }
    }

    public void UseEquipment() {
        TriggerInteract trigger = currentlyEquipped[0].GetComponent <TriggerInteract>(); 

        if (trigger) {
            trigger.Interact(); 
        }
    }
}
