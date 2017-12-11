using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Input/Profile")]
public class InputProfile : ScriptableObject {

	public int playerIndex;
	public bool useMouse;

	[Header("Axes")]
	[SerializeField]
	string horizontalMove;
	[SerializeField]	
	string verticalMove;

	[Space]
	[SerializeField]
	string horizontalLook;
	[SerializeField]
	string verticalLook;

	[Header("Buttons")]
	[SerializeField]
	string shoot;

	public string HorizontalMove { get { return horizontalMove; } }
	public string VerticalMove { get{ return verticalMove; } }

	public string HorizontalLook { get { return horizontalLook; } }
	public string VerticalLook { get { return verticalLook; } }

	public string Shoot { get { return shoot; } }
}
