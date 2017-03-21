using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRotate : MonoBehaviour {

	[SerializeField]
	private Transform pivot;

	[SerializeField]
	private float speed = 5.0f;

	[SerializeField]
	private float upAngle = 15.0f;
	[SerializeField]
	private float downAngle = -45.0f;

	[SerializeField]
	private float resetTime = 1.0f;

	private float rotX;

	private bool isMoving = false;


	void Update () 
	{
		//pivot.localRotation = Quaternion.Euler(Mathf.Sin(Time.timeSinceLevelLoad * speed) * range, 0.0f, 0.0f);
	}

	public void StartMove()
	{
		if(!isMoving)
			StartCoroutine(MoveLever());
	}

	private IEnumerator MoveLever()
	{
		isMoving = true;

		rotX = upAngle;
		while(rotX > downAngle)
		{
			rotX = Mathf.MoveTowards(rotX, downAngle, Time.deltaTime * speed);
			pivot.localRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
			yield return null;
		}

		yield return new WaitForSeconds(resetTime);

		while(rotX < upAngle)
		{
			rotX = Mathf.MoveTowards(rotX, upAngle, Time.deltaTime * (speed/1.75f));
			pivot.localRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
			yield return null;
		}

		isMoving = false;
		yield return null;
	}
}

