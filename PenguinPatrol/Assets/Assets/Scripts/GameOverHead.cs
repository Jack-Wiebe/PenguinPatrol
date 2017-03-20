using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOverHead{
	//Cameras used for the Security Controller
	private static Camera[] cameras = new Camera[6];
	//bool states for each room whether alarm is called or not
	private static bool[] alarms = new bool[6];

	//Cameras Indices
	private static int firstScreenIndex;
	private static int secondScreenIndex;
	private static int thirdScreenIndex;

	//MovementSpeeds
	private static float playerMovementSpeed;
	private static float guardMovementSpeed;
	private static float playerMinSpeed = 50; // change it to appropriate values
	private static float playerMaxSpeed = 100; // change it to appropriate values
	private static float guardRunMovementSpeed;
	private static bool isMoving;

	//Cooldowns
	private static float deactivationChannelTime;
	private static float guardRestingTime;
	private static int guardCalls;

	//Player states
	private static bool isCaught;
	private static bool isInteracting;

	//Guard states


	public static void Start()
	{
		alarms [0] = false; alarms [1] = false; alarms [2] = false; alarms [3] = false; alarms [4] = false; alarms [5] = false;
		firstScreenIndex = 1;
		secondScreenIndex = 2;
		thirdScreenIndex = 3;
		playerMovementSpeed = playerMaxSpeed;
		isMoving = true;

	}

	public static int GetFirstScreenIndex()
	{
		return firstScreenIndex;
	}
	public static void SetFirstScreenIndex(int newIndex)
	{
		firstScreenIndex = newIndex;
	}

	public static int GetSecondScreenIndex()
	{
		return secondScreenIndex;
	}
	public static void SetSecondScreenIndex(int newIndex)
	{
		secondScreenIndex = newIndex;
	}

	public static int GetThirdScreenIndex()
	{
		return thirdScreenIndex;
	}

	public static void SetThirdScreenIndex(int newIndex)
	{
		thirdScreenIndex = newIndex;
	}

	public static void SetPlayerMovementSpeed(float newSpeed)
	{
		playerMovementSpeed = newSpeed;
	}
	public static void slowPlayerDown()
	{
		playerMovementSpeed = playerMinSpeed;
	}

	public static void immobilizePlayer()
	{
		playerMovementSpeed = 0;
		isMoving = false;
	}

	public static float GetGuardSpeed()
	{
		return guardMovementSpeed;
	}

	public static void SetGuardSpeed(float newSpeed)
	{
		guardMovementSpeed = newSpeed;
	}
	public static float GetGuardRunSpeed()
	{
		return guardRunMovementSpeed;
	}

	public static void SetGuardRunSpeed(float newSpeed)
	{
		guardRunMovementSpeed = newSpeed;
	}

	public static void increaseDeactivationTime()
	{
		deactivationChannelTime += 10; //change to appropriate value
	}

	public static void calledGuard()
	{
		guardCalls--;
	}

	public static int GetGuardCall()
	{
		return guardCalls;
	}

	public static void ResetMovement()
	{
		isMoving = true;
	}

 }
