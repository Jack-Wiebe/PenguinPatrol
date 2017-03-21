using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityMapMonitor : MonoBehaviour {

	[SerializeField]
	private Vector3[] positions;//0 - left, 1 - right, 2 - middle

	private int currentPos = 0;

	private float posX;
	private float posY;
	private float destX;
	private float destY;

	[SerializeField]
	private float speed = 5.0f;

	private bool isMoving = false;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StartMove();
		}
	}

	public void StartMove()
	{	
		if(!isMoving)
		{
			int ran = Random.Range(0, positions.Length);
			//Debug.Log(ran);
			Debug.Log("From: " + currentPos + ", to: " + ran);

			StartCoroutine(MoveMonitor(currentPos, ran));
		}
	}

	private IEnumerator MoveMonitor(int curPosIndex ,int posIndex)
	{
		isMoving = true;
		this.transform.localPosition = positions[currentPos];

		yield return StartCoroutine(moveToMiddle(curPosIndex));

		while(!Input.anyKeyDown)
		{
			yield return null;
		}

		yield return StartCoroutine(moveOffScreen(posIndex));

		isMoving = false;
		yield return null;
	}

	private IEnumerator moveToMiddle(int index)
	{
		posX = positions[index].x;
		posY = positions[index].y;

		switch (index)
		{
			case 0:
				while(posX < 0.0f)
				{
					posX = Mathf.MoveTowards(posX, 0.0f, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(posX, this.transform.localPosition.y, this.transform.localPosition.z);
					yield return null;
				}
				break;

			case 1:
				while(posX > 0.0f)
				{
					posX = Mathf.MoveTowards(posX, 0.0f, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(posX, this.transform.localPosition.y, this.transform.localPosition.z);
					yield return null;
				}
				break;

			case 2:
				while(posY > 4.0f)
				{
					posY = Mathf.MoveTowards(posY, 4.0f, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(this.transform.localPosition.x, posY, this.transform.localPosition.z);
					yield return null;
				}
				break;

			default:
				break;
		}

		yield return null;
	}

	private IEnumerator moveOffScreen(int index)
	{
		destX = positions[index].x;
		destY = positions[index].y;

		switch(index)
		{
			case 0:
				while(posX > destX)
				{
					posX = Mathf.MoveTowards(posX, destX, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(posX, this.transform.localPosition.y, this.transform.localPosition.z);
					yield return null;
				}
				break;

			case 1:
				while(posX < destX)
				{
					posX = Mathf.MoveTowards(posX, destX, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(posX, this.transform.localPosition.y, this.transform.localPosition.z);
					yield return null;
				}
				break;

			case 2:
				while(posY < destY)
				{
					posY = Mathf.MoveTowards(posY, destY, Time.deltaTime * speed);
					this.transform.localPosition = new Vector3(this.transform.localPosition.x, posY, this.transform.localPosition.z);
					yield return null;
				}
				break;

			default:
				break;
		}

		currentPos = index;
		yield return null;
	}

}
