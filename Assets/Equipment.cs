using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

	public Inventory inventory;
	public Transform weaponSlot;
	public Transform otherSlot;

	public void AddItem(Collectable collectable){
		Storeable storeable = collectable.GetComponent<Storeable>();
		if(storeable){
			AddItem(storeable);
		}
	}

	public void AddItem(Storeable storeable){
		inventory.AddItem(storeable);
	}

	public void RemoveItem(Storeable storeable){
		inventory.RemoveItem(storeable);
	}
}
