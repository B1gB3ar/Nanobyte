using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoBit : Character {

	public bool isSelected; //If this is not selected, we will inlcude this in our calculation

	public NanoBit()
	{
		isSelected = false;
		base.location = Vector2.zero;
	}
	public NanoBit(bool selected, int aHealth, float aSpeed, Vector2 aLocation) : base(aHealth, aSpeed, aLocation)
	{

		setSelection(selected);

	}

	public void setSelection(bool selected)
	{
		isSelected = selected;
	}

	public bool getSelection()
	{
		return isSelected;
	}

}
