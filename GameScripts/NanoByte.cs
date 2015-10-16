using UnityEngine;
using System.Collections;

[System.Serializable]
public class NanoByte : Character {
		
	public int experiencePoints;

	public NanoByte()
	{
		attackValues = new AttackValues(10, 0, 0, 0, 0);
		base.setHealth(100);
		base.setSpeed(5.0f);
		base.setLocation(Vector3.zero);
		experiencePoints = 0;
	}
	public NanoByte(int aHealth, float aSpeed, int anAttack, int expPts, Vector2 aLocation) : base(aHealth, aSpeed, 
	                                                                                               aLocation)
	{
		attackValues.setStandardAttack(anAttack);
		this.setExperience(expPts);	
	}

	public void setExperience(int expPts)
	{
		experiencePoints = expPts;
	}
	public int getExperience()
	{
		return experiencePoints;
	}

	public void levelUpHealth(int aHealth)
	{
		base.setHealth(aHealth);
	}
	public void levelUpAttack(int anAttack)
	{
		attackValues.setStandardAttack(anAttack);
	}
	public void levelUpSpeed(float aSpeed)
	{
		base.setSpeed(aSpeed);
	}
}