using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TagCheck {

	public Tag tag;

	public UnityGameObjectEvent acceptedTagFound;

	public void CheckTags(Taggable taggable){
		if(taggable.Contains(tag)){
			acceptedTagFound.Invoke(taggable.gameObject);
		}
	}

}
