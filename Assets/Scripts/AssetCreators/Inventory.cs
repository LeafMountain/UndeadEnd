using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

	public int size;
	public GameEvent inventoryUpdatedEvent;

	[Space]	
	public List<InventoryItem> items = new List<InventoryItem>();

	public void AddItem(InventoryItem item){
		if(items.Count < size){
			items.Add(item);
			inventoryUpdatedEvent.Raise();
		}
	}

	public void RemoveItem(InventoryItem item){
		if(items.Contains(item)){
			items.Remove(item);
			inventoryUpdatedEvent.Raise();
		}
	}

	public void RemoveItem(int index){
		if(items.Count > index){
			items.RemoveAt(index);
			inventoryUpdatedEvent.Raise();		
		}
	}

	public void MoveToBack(InventoryItem item){
		if(items.Contains(item)){
			items.Add(item);
			items.RemoveAt(0);
			inventoryUpdatedEvent.Raise();			
		}
	}
}
