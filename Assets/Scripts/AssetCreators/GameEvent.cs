using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/GameEvent")]
public class GameEvent : ScriptableObject {

	List<GameEventListener> listeners = new List<GameEventListener>();

	public void AddListener(GameEventListener listener){
		if(!ListenerExists(listener)){
			listeners.Add(listener);
		}
	}

	public void RemoveListener(GameEventListener listener){
		if(ListenerExists(listener)){
			listeners.Remove(listener);
		}
	}

	bool ListenerExists(GameEventListener listener){
		return listeners.Contains(listener);
	}

	public void Raise(){
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].Raised();
		}
	}
}
