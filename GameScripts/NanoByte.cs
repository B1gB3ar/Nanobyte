using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class NanoByte : Character {
		
	public int experiencePoints;

	public NanoByte()
	{
		base.attackValues = new AttackValues(10, 0);
		base.setHealth(100.0f);
		base.setSpeed(5.0f);
		base.setLocation(Vector3.zero);
		this.experiencePoints = 0;
	}
	public NanoByte(float aHealth, float aSpeed, float anAttack, int expPts, float usage, Vector2 aLocation) : 
		base(aHealth, aSpeed, aLocation)
	{
		base.attackValues.setStandardAttack(anAttack);
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

	public void levelUpHealth(float aHealth, Slider healthBar)
	{
		base.setHealth(base.getHealth() + aHealth);
		healthBar.maxValue = base.getHealth();
	}
	public void levelUpSpeed(float aSpeed)
	{
		base.setSpeed(base.getSpeed() + aSpeed);
	}

	public void updateHealth(Slider healthBar)
	{
		healthBar.value = base.getHealth();
	}
	public void inflictDamage(float damage)
	{
		base.setHealth(base.getHealth() - damage);
	}

}