using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class ThiefController : MonoBehaviour{

	public int playerId = 0; // The Rewired player id of this character
	public float moveSpeed = 3.0f;

	private Player player; // The Rewired Player
	private Rigidbody rb;
	private Vector3 moveVector;
	private bool RT;
	private bool LT;
	private bool RB;
	private bool LB;
	private bool ButtonA;
	private bool ButtonX;
	private bool ButtonY;
	private bool ButtonB;
	private bool DpadUp;
	private bool DpadDown;
	private bool DpadRight;
	private bool DpadLeft;
	private bool RightStick;
	private bool LeftStick;


	void Awake() 
	{
		
		player = ReInput.players.GetPlayer(playerId);
		rb = this.GetComponent<Rigidbody>();
	}

	void Update ()
	{
		HandleInput();
	}

	void FixedUpdate () {

		GetInput();
		HandleMovement();
	}

	private void GetInput() {
		moveVector.x = player.GetAxis("MoveRight"); 
		moveVector.z = player.GetAxis("MoveForward");

		RT = player.GetButton("RightTrigger");
		LT = player.GetButton ("LeftTrigger");
		ButtonA = player.GetButton ("A");
		ButtonX = player.GetButton ("X");
		ButtonY = player.GetButton ("Y");
		ButtonB = player.GetButton ("B");
		DpadUp = player.GetButton ("Up");
		DpadDown = player.GetButton ("Down");
		DpadRight = player.GetButton ("Right");
		DpadLeft = player.GetButton ("Left");
		RightStick = player.GetButton ("RightStick");
		LeftStick = player.GetButton ("LeftStick");

	}

	private void HandleMovement()
	{
		
		if(moveVector.x != 0.0f || moveVector.z != 0.0f)
		{
		rb.MovePosition(this.transform.position + moveVector * moveSpeed * Time.deltaTime);
		}     
	}


	void HandleInput ()
	{

	////BUMPERS AND TRIGGERS AND THUMBSTICKS
	/// 
		if (player.GetButtonDown("RightTrigger"))
		{
			Debug.Log ("RightTigger");
		}

		if (player.GetButtonDown("LeftTrigger"))
		{
			Debug.Log ("LeftTrigger");
		}

		if (player.GetButtonDown("RightBumper"))
		{
			Debug.Log ("RightBumper");
		}

		if (player.GetButtonDown("LeftBumper"))
		{
			Debug.Log ("LeftBumper");
		}

		if (player.GetButtonDown("RightStick"))
		{
			Debug.Log ("RightStick");
		}

		if (player.GetButtonDown("LeftStick"))
		{
			Debug.Log ("LeftStick");
		}

	//// A X Y B BUTTONS
	/// 
		/// 
		if (player.GetButtonDown("A"))
		{
			Debug.Log ("A");
		}

		if (player.GetButtonDown("X"))
		{

			Debug.Log ("X");
		}

		if (player.GetButtonDown("Y"))
		{
			Debug.Log ("Y");
		}

		if (player.GetButtonDown("B"))
		{
			Debug.Log ("B");
		}

	//// D-PAD BUTTONS
	/// 

		if (player.GetButtonDown("Up"))
		{
			Debug.Log ("Up");
		}

		if (player.GetButtonDown("Down"))
		{

			Debug.Log ("Down");
		}

		if (player.GetButtonDown("Right"))
		{
			Debug.Log ("Right");
		}

		if (player.GetButtonDown("Left"))
		{
			Debug.Log ("Left");
		}
	}
}