using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityInput : MonoBehaviour {

	[SerializeField]
	private Camera mainCam;

	void Update ()
	{
		checkForInput();
	}

	private void checkForInput ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = mainCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
			{
				string tag = hit.transform.tag;

				switch (tag) 
				{
					case "SecurityButton":
						Debug.Log("THATS A BUTTON YEAHHHHHH");
						break;

					case "SecurityLever":
						Debug.Log("THATS A LEVER YEAHHHHHH");
						break;

					default:
						break;
				}
			}
		}
	}
}
