using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Character {

	public float health;
	public float speed;
	public Vector2 location;
	public int numberOfSpawned;
	public bool isMovingToAttack;
	public bool isAttacking;
	
	public bool firstPass = true;
	public Transform enemyPosition;
	public int randNumb = 1;
	public Vector3 finalPos;

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
	public void setEnemyPos(Transform enemyPos)
	{
		enemyPosition = enemyPos;
	}
	public void setMoveToAttack(bool moveTo)
	{
		isMovingToAttack = moveTo;
	}
	public void setAttacking(bool attack)
	{
		isAttacking = attack;
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
	public bool getMoveToAttack()
	{
		return isMovingToAttack;
	}
	public bool getAttacking()
	{
		return isAttacking;
	}

	public void resetFirstPass()
	{
		randNumb = Random.Range(1, 9);
		firstPass = true;
	}
	public void resetAttackSequence()
	{
		this.setMoveToAttack(false);
		this.setAttacking(false);
		this.setEnemyPos(null);
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
		isMovingToAttack = false;
		currPos.position = Vector3.MoveTowards(currPos.position, initialPos.position, Time.deltaTime * 6f);
	}

	public void moveToAttack(Transform currPos, Transform enemyPos)
	{
		currPos.position = Vector3.MoveTowards(currPos.position, enemyPos.position, Time.deltaTime * 4f);
	}
	
	public void startToAttack(Transform currPos, Transform enemyPos)
	{
		//TODO Add animation or something? Change Parameters...?
	}

	public void charMovement(Transform currPos, float moveByHowMuch, int howFast)
	{
		float heading = 0f;
		
		switch(randNumb)
		{
		case 1: // Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 0);
			break;
		case 2: // Up
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, 1);
			break;
		case 3: // Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 0);
			break;
		case 4: // Down
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, -1);
			break;
		case 5: // Up & Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 1);
			break;
		case 6: // Up & Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 1);
			break;
		case 7: // Down & Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, -1);
			break;
		case 8: // Down & Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}	
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, -1);
			break;
		default:
			break;
		}

		if(currPos.position.x >= finalPos.x - .1f)
		{
			Debug.Log("Reached");
			resetFirstPass();
		}
		currPos.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
	}
}