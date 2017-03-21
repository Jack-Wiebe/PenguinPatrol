using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour {

	[SerializeField]
	private Transform push;

	[SerializeField]
	private float speed = 5.0f;

	[SerializeField]
	private float range = 0.15f;

	[SerializeField]
	private float resetTime = 1.0f;

	private float posY;

	private bool isMoving = false;

	void Update () 
	{
		//this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Sin(Time.timeSinceLevelLoad * speed) * range, this.transform.localPosition.z);
	}

	public void StartMove()
	{
		if(!isMoving)
			StartCoroutine(MoveButton());
	}

	private IEnumerator MoveButton()
	{
		isMoving = true;
		posY = push.localPosition.y;

		while(posY > range)
		{
			posY = Mathf.MoveTowards(posY, range, Time.deltaTime * (speed/2));
			push.localPosition = new Vector3(0.0f, posY, 0.0f);
			yield return null;
		}

		yield return new WaitForSeconds(resetTime);

		while(posY < 0.0f)
		{
			posY = Mathf.MoveTowards(posY, 0.0f, Time.deltaTime * speed);
			push.localPosition = new Vector3(0.0f, posY, 0.0f);
			yield return null;
		}

		isMoving = false;
		yield return null;
	}
}

