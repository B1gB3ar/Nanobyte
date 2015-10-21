using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class NanoByte : Character {
		
	public int experiencePoints;
	public float usageAmount = 100;

	public NanoByte()
	{
		base.attackValues = new AttackValues(10, 0, 0, 0, 0);
		base.setHealth(100.0f);
		base.setSpeed(5.0f);
		base.setLocation(Vector3.zero);
		this.experiencePoints = 0;
		this.usageAmount = 100;
	}
	public NanoByte(float aHealth, float aSpeed, float anAttack, int expPts, float usage, Vector2 aLocation) : 
		base(aHealth, aSpeed, aLocation)
	{
		base.attackValues.setStandardAttack(anAttack);
		this.setExperience(expPts);	
		this.setUsageAmount(usage);
	}

	public void setExperience(int expPts)
	{
		experiencePoints = expPts;
	}
	public void setUsageAmount(float usage)
	{
		usageAmount = usage;
	}
	public int getExperience()
	{
		return experiencePoints;
	}
	public float getUsageAmount()
	{
		return usageAmount;
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
	public void updateUsage(Slider usageBar)
	{
		usageBar.value = this.getUsageAmount();
	}
	public void decrementUsageBarBySpec1()
	{
		this.setUsageAmount(this.getUsageAmount() - base.attackValues.getUsageSpec1());
	}
	public void decrementUsageBarBySpec2()
	{
		this.setUsageAmount(this.getUsageAmount() - base.attackValues.getUsageSpec2());
	}
	public void decrementUsageBarBySpec3()
	{
		this.setUsageAmount(this.getUsageAmount() - base.attackValues.getUsageSpec3());
	}
	public void decrementUsageBarBySpec4()
	{
		this.setUsageAmount(this.getUsageAmount() - base.attackValues.getUsageSpec4());
	}

}