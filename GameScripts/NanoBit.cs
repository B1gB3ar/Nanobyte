using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoBit : Character {

	public bool isSelected;
	public bool containedWithByte;
	public bool isAttacking;
	public Transform enemyPosition;

	public NanoBit()
	{
		isSelected = false;
		containedWithByte = false;
		base.location = Vector2.zero;
	}
	public NanoBit(bool selected, bool contained, int aHealth, float aSpeed, Vector2 aLocation) : base(aHealth, aSpeed, aLocation)
	{
		setSelection(selected);
		setContainment(contained);
	}

	public void setSelection(bool selected)
	{
		isSelected = selected;
	}
	public void setContainment(bool contained)
	{
		containedWithByte = contained;
	}
	public void setEnemyPos(Transform enemyPos)
	{
		enemyPosition = enemyPos;
	}
	
	public bool getSelection()
	{
		return isSelected;
	}
	public bool getContainment()
	{
		return containedWithByte;
	}
	public Transform getEnemyPos()
	{
		return enemyPosition;
	}

	public void stopNanoBitMovement()
	{
		// I believe this stops the movement with no computations being made
	}

	public void nanoBitMovement(Transform nanoBitPos)
	{
		int randNumb = Random.Range(1, 9);
		float heading = 0f;

		switch(randNumb)
		{
		case 1: // Right
			nanoBitPos.position += new Vector3(5, 0, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, 0);
			break;
		case 2: // Up
			nanoBitPos.position += new Vector3(0, 5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(0, 1);
			break;
		case 3: // Left
			nanoBitPos.position += new Vector3(-5, 0, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, 0);
			break;
		case 4: // Down
			nanoBitPos.position += new Vector3(0, -5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(0, -1);
			break;
		case 5: // Up & Right
			nanoBitPos.position += new Vector3(5, 5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, 1);
			break;
		case 6: // Up & Left
			nanoBitPos.position += new Vector3(-5, 5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, 1);
			break;
		case 7: // Down & Right
			nanoBitPos.position += new Vector3(5, -5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, -1);
			break;
		case 8: // Down & Left
			nanoBitPos.position += new Vector3(-5, -5, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, -1);
			break;
		default:
			break;
		}
		nanoBitPos.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);
	}

	public void nanoBitMoveBack(Transform nanoBitPos)
	{
		isAttacking = false;
		nanoBitPos.position = Vector3.MoveTowards(nanoBitPos.position, 
		                                          GameObject.FindGameObjectWithTag("Player").transform.position, 
		                                          Time.deltaTime * 6f);
	}

	public void moveToAttack(Transform nanoBitPos, Transform enemyPos)
	{
		Debug.Log("Attack!");
		nanoBitPos.position = Vector3.MoveTowards(nanoBitPos.position, enemyPos.position, Time.deltaTime * 4f);
	}
}
