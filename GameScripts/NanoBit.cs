using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoBit : Character {

	public bool isSelected;
	public bool containedWithByte;
	public bool isMovingToAttack;
	public bool isAttacking;

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
	}
	
}
