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
			// return item;
		}

		// return null;
	}

	public InventoryItem RemoveItem(int index){
		InventoryItem item = null;
		
		if(items.Count > index){
			item = items[index];
			items.RemoveAt(index);
			inventoryUpdatedEvent.Raise();
		}

		return item;
	}

	public void MoveToBack(InventoryItem item){
		if(items.Contains(item)){
			items.Add(item);
			items.RemoveAt(0);
			inventoryUpdatedEvent.Raise();			
		}
	}

	public InventoryItem ReplaceItem(InventoryItem newItem, int slot){
		if(slot > items.Count){
			return null;
		}

		InventoryItem oldItem = items[slot];
		items[slot] = newItem;
		return oldItem;
	}
}
