using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

	public FloatReference inventorySize;
	public List<Storeable> items = new List<Storeable>();

	public bool AddItem(Storeable storeable){
		if(items.Count < inventorySize.Value && !items.Contains(storeable)){
			items.Add(storeable);
			return true;
		}

		return false;
	}

	public void RemoveItem(Storeable storeable){
		if(items.Contains(storeable)){
			items.Remove(storeable);
		}
	}
}
