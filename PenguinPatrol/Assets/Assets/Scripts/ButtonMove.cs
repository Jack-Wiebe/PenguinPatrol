using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour {

	[SerializeField]
	private float speed = 5.0f;

	[SerializeField]
	private float range = 0.15f;

	void Update () 
	{
		this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Sin(Time.timeSinceLevelLoad * speed) * range, this.transform.localPosition.z);
	}
}

