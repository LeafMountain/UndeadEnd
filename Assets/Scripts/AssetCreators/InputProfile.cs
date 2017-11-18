using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Input/Profile")]
public class InputProfile : ScriptableObject {

	public bool useMouse;

	public string horizontalMove;
	public string verticalMove;

	public string horizontalLook;
	public string verticalLook;

	public string shoot;
	public string toggleFlashlight;
}
