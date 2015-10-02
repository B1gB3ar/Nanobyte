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
	//public int attack;
	public float speed;

	/*
	 * 
	 * Default Constructor
	 * 
	 */ 
	public Character()
	{

		health = 100;
		//attack = 10;
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
		//setAttack(anAttVal);
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

	//TODO I BELIEVE WE WILL BE USING AttackValues FOR OUR ATTACKING INSTEAD OF THIS METHOD
	/*public void setAttack(int anAttVal)
	{

		attack = anAttVal;

	}*/

	public void setSpeed(int aSpeedVal)
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

	/*public int getAttack()
	{

		return attack;

	}*/

	public float getSpeed()
	{

		return speed;

	}

}
