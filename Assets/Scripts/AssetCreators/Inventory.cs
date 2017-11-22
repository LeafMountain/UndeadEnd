using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

	public int size;
	public List<Storeable> items = new List<Storeable>();

	public bool AddItem(Storeable storeable){
		if(items.Count < size && !items.Contains(storeable)){
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
