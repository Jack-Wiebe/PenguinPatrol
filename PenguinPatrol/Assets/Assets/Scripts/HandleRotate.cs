using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRotate : MonoBehaviour {

	[SerializeField]
	private float speed = 5.0f;

	[SerializeField]
	private float range = 30.0f;

	void Update () 
	{
		this.transform.localRotation = Quaternion.Euler(Mathf.Sin(Time.timeSinceLevelLoad * speed) * range, 0.0f, 0.0f);
	}
}

