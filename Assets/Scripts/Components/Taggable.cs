using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour {

	[SerializeField]
	private List<Tag> tags;

	public List<Tag> GetTags(){
		return tags;
	}

	public bool Contains(Tag tag){
		return tags.Contains(tag);
	}
}
