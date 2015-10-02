using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoByte : Character {
		
	public int experiencePoints;
	public AttackValues attackValues;

	/*
	 *
	 *	Calling the base class of Character to set the values of health and such
	 * 
	**/
	public NanoByte()
	{
		attackValues = new AttackValues(10, 0, 0, 0, 0);
		setHealth(100);
		setSpeed(5);
		experiencePoints = 0;
	}
	public NanoByte(int aHealth, int anAttack, int aSpeed, int expPts) : base(aHealth, aSpeed)
	{
		attackValues.setStandardAttack(anAttack);
		setExperience(expPts);	
	}

	public void setExperience(int expPts)
	{

		experiencePoints = expPts;

	}

	public int getExperience()
	{

		return experiencePoints;

	}

	/*
	 * 
	 * TODO Do we want to increase by a certain value, or just set it to what we want?
	 * 	Like so: getHealth() + aHealth; OR setHealth(aHealth); OR setHealth(getHealth() + aHealth);
	 * 
	 * 
	**/ 
	public void levelUpHealth(int aHealth)
	{

		setHealth(aHealth);

	}

	/*
	 * 
	 * TODO We can set up buttons to correspond to int values, and pass them in here and in the AttackValues
	 * 	class in order to manipulate the attack values in-game
	 * 
	**/
	public void levelUpAttack(int anAttack)
	{
		
		attackValues.setStandardAttack(anAttack);
		
	}

	public void levelUpSpeed(int aSpeed)
	{
		
		setSpeed(aSpeed);
		
	}

}
