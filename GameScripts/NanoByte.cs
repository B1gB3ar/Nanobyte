using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoByte : Character {
		
	public int experiencePoints;

	/*
	 *
	 *	Calling the base class of Character to set the values of health and such
	 * 
	**/
	public NanoByte()
	{

		setHealth(100);
		setAttack(10);
		setSpeed(5);
		experiencePoints = 0;

	}

	public NanoByte(int aHealth, int anAttack, int aSpeed, int expPts) : base(aHealth, anAttack, aSpeed)
	{

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

	public void levelUpAttack(int anAttack)
	{
		
		setAttack(anAttack);
		
	}

	public void levelUpSpeed(int aSpeed)
	{
		
		setSpeed(aSpeed);
		
	}

}
