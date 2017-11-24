using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Equipment : MonoBehaviour {

	public Inventory inventory;
	public GameObject currentlyEquipped;

	public UnityGameObjectEvent addedItem;

	int currentIndex = 0;

	public void AddItem(GameObject go){
		Storeable storeable = go.GetComponent<Storeable>();
		if(storeable){
			AddItem(storeable);

			if(!currentlyEquipped){
				currentlyEquipped = go;
			}
		}
	}

	public void AddItem(Storeable storeable){
		inventory.AddItem(storeable);
		addedItem.Invoke(storeable.gameObject);
	}

	public void RemoveItem(Storeable storeable){
		inventory.RemoveItem(storeable);
	}

	public Storeable NextObjectInList(){
		currentIndex++;
		return inventory.items[currentIndex % inventory.size];
	}

	public void InteractWithCurrentlyEquipment(){
		if(currentlyEquipped){
			TriggerInteract trigger = currentlyEquipped.GetComponent<TriggerInteract>();

			if(trigger){
				trigger.Interact();
			}
		}
	}
}
