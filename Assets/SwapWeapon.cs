using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour {

	public Inventory inventory;
	public GameEvent gameEvent;

	public void SwitchWeapon(){
		InventoryItem item = inventory.items[0];

		inventory.MoveToBack(item);
	}
}
