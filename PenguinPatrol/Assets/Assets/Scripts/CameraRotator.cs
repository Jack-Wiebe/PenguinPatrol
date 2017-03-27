using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {

	Quaternion one;
	Quaternion two;
	// Use this for initialization
	void Start () {
		one = this.transform.rotation;
		two = Quaternion.AngleAxis (270, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.Slerp (one, two, Mathf.Sin (Time.time));
	}
}
