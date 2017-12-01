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
		if(items.Count < size && !items.Contains(item)){
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
}
