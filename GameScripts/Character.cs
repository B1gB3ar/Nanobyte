using UnityEngine;
using System.Collections;
[System.Serializable]
public class Character {

	public int health;
	public float speed;
	public AttackValues attackValues;

	public Character()
	{
		health = 100;
		speed = 5.0f;
	}
	public Character(int aHealthVal, float aSpeedVal)
	{
		setHealth(aHealthVal);
		setSpeed(aSpeedVal);
	}

	public void setHealth(int aHealthVal)
	{
		health = aHealthVal;
	}
	public void setSpeed(float aSpeedVal)
	{
		speed = aSpeedVal;
	}
 
	public int getHealth()
	{
		return health;
	}
	public float getSpeed()
	{
		return speed;
	}
}