using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/GameEvent")]
public class GameEvent : ScriptableObject {

	List<UnityAction> listeners = new List<UnityAction>();

	public void AddListener(UnityAction listener){
		if(!ListenerExists(listener)){
			listeners.Add(listener);
		}
	}

	public void RemoveListener(UnityAction listener){
		if(ListenerExists(listener)){
			listeners.Remove(listener);
		}
	}

	bool ListenerExists(UnityAction listener){
		return listeners.Contains(listener);
	}

	public void Raise(){
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].Invoke();
		}
	}
}
