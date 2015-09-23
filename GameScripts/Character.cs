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
	public int attack;
	public int speed;

	/*
	 * 
	 * Default Constructor
	 * 
	 */ 
	public Character()
	{

		health = 100;
		attack = 10;
		speed = 5;

	}

	/*
	 * 
	 * Parameter Constructor
	 * 
	 */ 
	public Character(int aHealthVal, int anAttVal, int aSpeedVal)
	{

		setHealth(aHealthVal);
		setAttack(anAttVal);
		setSpeed(aSpeedVal);

	}

	/*
	 * 
	 * Accessors
	 * 
	 */ 
	public void setHealth(int aHealthVal)
	{

		health = aHealthVal;

	}

	public void setAttack(int anAttVal)
	{

		attack = anAttVal;

	}

	public void setSpeed(int aSpeedVal)
	{

		speed = aSpeedVal;

	}

	/*
	 * 
	 * Mutators
	 * 
	 */ 
	public int getHealth()
	{

		return health;

	}

	public int getAttack()
	{

		return attack;

	}

	public int getSpeed()
	{

		return speed;

	}

}
