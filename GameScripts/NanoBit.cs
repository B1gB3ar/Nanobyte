using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoBit : Character {

	public bool isSelected; //If this is not selected, we will inlcude this in our calculation
	public bool containedWithByte;

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
	
	public bool getSelection()
	{
		return isSelected;
	}
	public bool getContainment()
	{
		return containedWithByte;
	}

	public void stopNanoBitMovement()
	{

		// I believe this stops the movement with no computations being made
		//TODO Stop the movement of the bit while selected

	}
	public void nanoBitMovement(Transform movement)
	{

		int randNumb = Random.Range(1, 9);
		float heading = 0f;

		switch(randNumb)
		{
		case 1: // Right
			movement.position += new Vector3(1, 0, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, 0);
			break;
		case 2: // Up
			movement.position += new Vector3(0, 1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(0, 1);
			break;
		case 3: // Left
			movement.position += new Vector3(-1, 0, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, 0);
			break;
		case 4: // Down
			movement.position += new Vector3(0, -1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(0, -1);
			break;
		case 5: // Up & Right
			movement.position += new Vector3(1, 1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, 1);
			break;
		case 6: // Up & Left
			movement.position += new Vector3(-1, 1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, 1);
			break;
		case 7: // Down & Right
			movement.position += new Vector3(1, -1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(-1, -1);
			break;
		case 8: // Down & Left
			movement.position += new Vector3(-1, -1, 0) * Time.deltaTime;
			heading = Mathf.Atan2(1, -1);
			break;
		default:
			break;

		}
		movement.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);

	}

	public void nanoBitMoveBack(Transform movement)
	{

		movement.position = Vector3.MoveTowards(movement.position, 
		                                        GameObject.FindGameObjectWithTag("Player").transform.position,
		                                        Time.deltaTime * 5);

	}

}
