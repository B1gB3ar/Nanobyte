using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Character {

	public float health;
	public float speed;
	public Vector2 location;
	public int numberOfSpawned;

	public AttackValues attackValues;
	public bool firstPass = true;
	public Transform enemyPosition;
	public int randNumb = 1;
	public Vector3 finalPos;

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
	public void setEnemyPos(Transform enemyPos)
	{
		enemyPosition = enemyPos;
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
	public Transform getEnemyPos()
	{
		return enemyPosition;
	}

	public void spawn(GameObject characterGameObject, Character spawner,
	                         List<GameObject> listOfSpawned)
	{
		characterGameObject.transform.position = spawner.getLocation();
		characterGameObject.name = characterGameObject.name + numberOfSpawned;
		listOfSpawned.Add(characterGameObject);
		++numberOfSpawned;
	}

	public void moveBack(Transform currPos, Transform initialPos)
	{
//		isMovingToAttack = false;
		currPos.position = Vector3.MoveTowards(currPos.position, initialPos.position, Time.deltaTime * 6f);
	}

	public void moveToAttack(Transform currPos, Transform enemyPos)
	{
		currPos.position = Vector3.MoveTowards(currPos.position, enemyPos.position, Time.deltaTime * 4f);
	}
	
	public void startToAttack(Transform nanoBitPos, Transform enemyPos)
	{
		//TODO Add animation or something? Change Parameters...?
	}

	public void nanoBitMovement(Transform nanoBitPos, float moveByHowMuch, int howFast)
	{
		float heading = 0f;
		
		switch(randNumb)
		{
		case 1: // Right
			if(firstPass)
			{
				Debug.Log("Passing...");
				finalPos = new Vector3(nanoBitPos.position.x + moveByHowMuch, nanoBitPos.position.y, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 0);
			break;
		case 2: // Up
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x, nanoBitPos.position.y + moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, 1);
			break;
		case 3: // Left
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x - moveByHowMuch, nanoBitPos.position.y, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 0);
			break;
		case 4: // Down
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x, nanoBitPos.position.y - moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, -1);
			break;
		case 5: // Up & Right
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x + moveByHowMuch, nanoBitPos.position.y + moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 1);
			break;
		case 6: // Up & Left
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x + moveByHowMuch, nanoBitPos.position.y - moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 1);
			break;
		case 7: // Down & Right
			if(firstPass)
			{
				finalPos = new Vector3(nanoBitPos.position.x - moveByHowMuch, nanoBitPos.position.y + moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, -1);
			break;
		case 8: // Down & Left
			if(firstPass)
			{
				Debug.Log("FirstPass");
				finalPos = new Vector3(nanoBitPos.position.x - moveByHowMuch, nanoBitPos.position.y - moveByHowMuch, nanoBitPos.position.z);
				firstPass = false;
			}	
			nanoBitPos.position = Vector3.Lerp(nanoBitPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, -1);
			break;
		default:
			break;
		}
		if(nanoBitPos.position.x >= finalPos.x - .1f)
		{
			Debug.Log("Reached");
			randNumb = Random.Range(1, 9);
			firstPass = true;
		}
		nanoBitPos.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);
	}
}