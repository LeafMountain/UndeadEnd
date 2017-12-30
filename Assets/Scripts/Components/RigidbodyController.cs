using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyController : MonoBehaviour {

	public enum Direction { Manual, Forward }
	public enum Mode { Once, Continuous }

	public Direction direction;
	public Mode mode;
	public Vector3 velocity;
	public float speed;

	Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();

		switch (direction)
		{
			case(Direction.Forward):
				SetVelocity(transform.forward, speed);
				break;
			case(Direction.Manual):
				SetVelocity(velocity, speed);
				break;
			default:
				break;
		}
	}

	void Update(){
		if(mode == Mode.Continuous){
			rb.AddForce(velocity * speed, ForceMode.VelocityChange);
		}
	}

	public void SetVelocity(Vector3 velocity, float speed){
		// this.velocity = velocity;
		rb.AddForce(velocity * speed, ForceMode.VelocityChange);		
	}
}
