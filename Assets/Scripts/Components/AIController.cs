using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour {

	IAIState currentState;
	public NavMeshAgent agent;
	public Tag targetTag;

	public Vector2 wanderLenghtMinMax = new Vector2(0, 5);

	public void ChangeState(IAIState newState){
		currentState = newState;
	}

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		currentState = new WanderState(this);
	}

	void Update(){
		Look();
		
		currentState.Update();
	}

	void Look(){
		RaycastHit hit;

		if(Physics.SphereCast(transform.position, 1, transform.forward, out hit, 10)){

			Taggable taggable = hit.transform.GetComponent<Taggable>();

			if(taggable && taggable.Contains(targetTag)){
				Debug.Log("Chasing player");
				//Chase state
				ChangeState(new ChaseState(this, taggable.transform.position));
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
	}
}
