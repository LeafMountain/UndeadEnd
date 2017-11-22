using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

	public Inventory inventory;
	public Storeable currentlyEquipped;

	public Transform equipSlot1;
	public Transform equipSlot2;

	int currentIndex = 0;

	public void AddItem(Collectable collectable){
		Storeable storeable = collectable.GetComponent<Storeable>();
		if(storeable){
			AddItem(storeable);

			if(!currentlyEquipped){
				Equip(storeable, equipSlot1);
			}
		}
	}

	public void AddItem(Storeable storeable){
		inventory.AddItem(storeable);
	}

	public void RemoveItem(Storeable storeable){
		inventory.RemoveItem(storeable);
	}

	public Storeable NextObjectInList(){
		currentIndex++;
		return inventory.items[currentIndex % inventory.size];
	}

	public void Equip(Storeable storeable, Transform equipTransform){
		if(equipSlot1){
			
		} else{
			currentlyEquipped = storeable;

		}

		storeable.transform.position = Vector3.zero;
		storeable.transform.rotation = Quaternion.identity;
		storeable.transform.SetParent(currentlyEquipped.transform);
	}

	public void UnEquip(){

	}
}
