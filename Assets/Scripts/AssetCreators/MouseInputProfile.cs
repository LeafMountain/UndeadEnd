using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Input/Mouse Profile")]
public class MouseInputProfile : ScriptableObject {

	public string horizontalMove;
	public string verticalMove;

	public string horizontalLook;
	public string verticalLook;

	public string shoot;
	public string toggleFlashlight;
}
