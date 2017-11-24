using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InputButton : MonoBehaviour {

	public PlayerIndex playerIndex;
	public GamePadButtons buttons;

	GamePadState state;

	void Update(){
		state = GamePad.GetState(playerIndex);
		Debug.Log(state.DPad.Up);
	}
}
