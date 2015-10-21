using UnityEngine;
using System.Collections;
[System.Serializable]
public class Character {

	public float health;
	public float speed;
	public Vector2 location;

	public AttackValues attackValues;

	public Character()
	{
		health = 100.0f;
		speed = 2.0f;
		location = Vector2.zero;
	}
	public Character(float aHealthVal, float aSpeedVal, Vector2 aLocation)
	{
		setHealth(aHealthVal);
		setSpeed(aSpeedVal);
		setLocation(aLocation);
	}

	public void setHealth(float aHealthVal)
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
 
	public float getHealth()
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