using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Transform weaponSlot;
	public Useable weapon;

	public void AddItem(Collectable collectable){
		Useable useable = collectable.GetComponent<Useable>();
		if(useable){
			AddWeapon(useable);
		}
	}

	public void AddWeapon(Useable useable){
		if(weapon){
			RemoveWeapon();
		}

		weapon = useable;

		useable.transform.position = Vector3.zero;
		useable.transform.rotation = Quaternion.identity;
		useable.transform.SetParent(weaponSlot, false);
	}

	public void RemoveWeapon(){
		weapon.GetComponent<Collectable>().Drop();
		weapon.transform.SetParent(null);
	}
}
