using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character {
	
	/*
	 * 
	 * Instance Variables
	 * 
	 */ 
	public int health;
	public float speed;

	/*
	 * 
	 * Default Constructor
	 * 
	 */ 
	public Character()
	{

		health = 100;
		speed = 5;

	}

	/*
	 * 
	 * Parameter Constructor
	 * 
	 */ 
	public Character(int aHealthVal, int aSpeedVal)
	{

		setHealth(aHealthVal);
		setSpeed(aSpeedVal);

	}

	/*
	 * 
	 * Mutators
	 * 
	 */ 
	public void setHealth(int aHealthVal)
	{

		health = aHealthVal;

	}
	public void setSpeed(float aSpeedVal)
	{

		speed = aSpeedVal;

	}

	/*
	 * 
	 * Accessing
	 * 
	 */ 
	public int getHealth()
	{

		return health;

	}
	public float getSpeed()
	{

		return speed;

	}

}
