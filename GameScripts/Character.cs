using UnityEngine;
using System.Collections;
[System.Serializable]
public class Character {

	public int health;
	public float speed;
	public Vector2 location;

	public AttackValues attackValues;

	public Character()
	{
		health = 100;
		speed = 5.0f;
		location = Vector2.zero;
	}
	public Character(int aHealthVal, float aSpeedVal, Vector2 aLocation)
	{
		setHealth(aHealthVal);
		setSpeed(aSpeedVal);
		setLocation(aLocation);
	}

	public void setHealth(int aHealthVal)
	{
		health = aHealthVal;
	}
	public void setSpeed(float aSpeedVal)
	{
		speed = aSpeedVal;
	}
	public void setLocation(Vector2 aLocation)
	{
		location = aLocation;
	}
 
	public int getHealth()
	{
		return health;
	}
	public float getSpeed()
	{
		return speed;
	}
	public Vector3 getLocation()
	{
		return location;
	}
}