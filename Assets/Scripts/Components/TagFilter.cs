using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagFilter : MonoBehaviour {

	public List<TagCheck> checks;

	public void CheckTags(GameObject go){
		Taggable taggable = go.GetComponent<Taggable>();

		if(taggable){
			for (int i = 0; i < checks.Count; i++){
				checks[i].CheckTags(taggable);
			}
		}
	}
}
