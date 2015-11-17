using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class AttackValues
{
	public float dmg_StandardAttack;
	public float dmg_lasers;
	
	public float usage_lasers = 1;
	public float usage_flashFreeze = 1;
	public float usage_stealth = 1;

	public float laserDecrement = 100;
	public float flashDecrement = 1;
	public float stealthDecrement = 100;

	public AttackValues()
	{
		dmg_StandardAttack = 5;
		dmg_lasers = 0;
	}
	public AttackValues(float stdAtt, float spec1)
	{
		setStandardAttack(stdAtt);
		this.setAttack_Lasers(spec1);
	}

	public void setStandardAttack(float stdAtt)
	{
		dmg_StandardAttack = stdAtt;	
	}
	public void setAttack_Lasers(float spec1)
	{
		dmg_lasers = spec1;	
	}

	public void setUsage_Lasers(float uSpec1)
	{
		usage_lasers = uSpec1;
	}
	public void setUsage_FlashFreeze(float uSpec2)
	{
		usage_flashFreeze = uSpec2;
	}
	public void setUsage_Stealth(float uSpec3)
	{
		usage_stealth = uSpec3;
	}

	public void setDecrement_Lasers(float decrement)
	{
		laserDecrement = decrement;
	}
	public void setDecrement_Flash(float decrement)
	{
		flashDecrement = decrement;
	}
	public void setDecrement_Stealth(float decrement)
	{
		stealthDecrement = decrement;
	}

	public float getStandardAttack()
	{		
		return dmg_StandardAttack;	
	}
	public float getAttack_Lasers()
	{
		return dmg_lasers;	
	}

	public float getUsage_Lasers()
	{
		return usage_lasers;
	}
	public float getUsage_FlashFreeze()
	{
		return usage_flashFreeze;
	}
	public float getUsage_Stealth()
	{
		return usage_stealth;
	}

	public float getDecrement_Lasers()
	{
		return laserDecrement;
	}
	public float getDecrement_Flash()
	{
		return flashDecrement;
	}
	public float getDecrement_Stealth()
	{
		return stealthDecrement;
	}

	public void levelUpAttack(float anAttack)
	{
		this.setStandardAttack(this.getStandardAttack() + anAttack);
	}
	public void levelUp_Lasers(float anAttack, float usageAmount)
	{
		this.setAttack_Lasers(this.getAttack_Lasers() + anAttack);
		//this.setUsage_Lasers(this.getUsage_Lasers() - usageAmount);
		this.setDecrement_Lasers(this.getDecrement_Lasers() * (1/10));
	}
	public void levelUp_FlashFreeze(float anAttack, float usageAmount)
	{
		/*
		 * Whole screen flash
		 * Stop enemies longer
		 */ 
		this.setDecrement_Flash(0.5f);
		Debug.Log(this.getDecrement_Flash());
	}
	public void levelUp_SlowFreeze(float anAttack, float usageAmount)
	{
		/*
		 * Update Radius
		 * Create a slower enemy
		 */ 
	}
	public void levelUp_Stealth(float anAttack, float usageAmount)
	{
		/*
		 * Invisible to enemies
		 */ 
		this.setDecrement_Stealth(this.getDecrement_Stealth() * (1/10));
	}
}