using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModify : MonoBehaviour {

	public Inventory inventory;

	public void Add(InventoryItem item){
		//Check if inventory is full
		inventory.AddItem(item);
	}

	public void Remove(InventoryItem item){
		inventory.RemoveItem(item);
	}

	public InventoryItem Drop(InventoryItem item){
		return item;
	}
}
