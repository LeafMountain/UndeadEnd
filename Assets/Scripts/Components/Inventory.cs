using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Transform weaponSlot;
	public Storeable weapon;

	public void AddItem(Collectable collectable){
		Storeable storeable = collectable.GetComponent<Storeable>();
		
		if(storeable){
			AddWeapon(storeable);
		}
	}

	public void AddWeapon(Storeable storeable){
		if(weapon){
			RemoveWeapon();
		}

		weapon = storeable;

		storeable.transform.position = Vector3.zero;
		storeable.transform.rotation = Quaternion.identity;
		storeable.transform.SetParent(weaponSlot, false);
	}

	public void RemoveWeapon(){
		weapon.GetComponent<Collectable>().Drop();
		weapon.transform.SetParent(null);
	}
}
