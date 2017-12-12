using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

	public Inventory inventory;
	public int index;
	public UnityGameObjectEvent OnEquip;
	
	GameObject currentEquipment;

	public void GetEquipment(){
		GameObject go = (inventory.items.Count >= index) ? inventory.items[index].prefab : null;

		if(go){
			OnEquip.Invoke(go);
		}
	}
}
