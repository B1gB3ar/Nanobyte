using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class AttackValues
{
	public float dmg_StandardAttack;
	public float dmg_Special1;
	public float dmg_Special2;
	public float dmg_Special3;
	public float dmg_Special4;
	
	public float usage_Spec1 = 30;
	public float usage_Spec2 = 30;
	public float usage_Spec3 = 30;
	public float usage_Spec4 = 30;

	public AttackValues()
	{
		dmg_StandardAttack = 5;
		dmg_Special1 = 0;
		dmg_Special2 = 0;
		dmg_Special3 = 0;
		dmg_Special4 = 0;
	}
	public AttackValues(float stdAtt, float spec1, float spec2, float spec3, float spec4)
	{
		setStandardAttack(stdAtt);
		setSpecial1Attack(spec1);
		setSpecial2Attack(spec2);
		setSpecial3Attack(spec3);
		setSpecial4Attack(spec4);
	}
	public void setStandardAttack(float stdAtt)
	{
		dmg_StandardAttack = stdAtt;	
	}
	public void setSpecial1Attack(float spec1)
	{
		dmg_Special1 = spec1;	
	}
	public void setSpecial2Attack(float spec2)
	{
		dmg_Special2 = spec2;	
	}
	public void setSpecial3Attack(float spec3)
	{
		dmg_Special3 = spec3;	
	}
	public void setSpecial4Attack(float spec4)
	{
		dmg_Special4 = spec4;	
	}
	public void setUsageSpec1(float uSpec1)
	{
		usage_Spec1 = uSpec1;
	}
	public void setUsageSpec2(float uSpec2)
	{
		usage_Spec2 = uSpec2;
	}
	public void setUsageSpec3(float uSpec3)
	{
		usage_Spec3 = uSpec3;
	}
	public void setUsageSpec4(float uSpec4)
	{
		usage_Spec4 = uSpec4;
	}

	public float getStandardAttack()
	{		
		return dmg_StandardAttack;	
	}
	public float getSpecial1Attack()
	{
		return dmg_Special1;	
	}
	public float getSpecial2Attack()
	{
		return dmg_Special2;	
	}
	public float getSpecial3Attack()
	{
		return dmg_Special3;	
	}
	public float getSpecial4Attack()
	{
		return dmg_Special4;	
	}
	public float getUsageSpec1()
	{
		return usage_Spec1;
	}
	public float getUsageSpec2()
	{
		return usage_Spec2;
	}
	public float getUsageSpec3()
	{
		return usage_Spec3;
	}
	public float getUsageSpec4()
	{
		return usage_Spec4;
	}

	public void levelUpAttack(float anAttack)
	{
		this.setStandardAttack(this.getStandardAttack() + anAttack);
	}
	public void levelUpSpec1Att(float anAttack, float usageAmount)
	{
		this.setSpecial1Attack(this.getSpecial1Attack() + anAttack);
		this.setUsageSpec1(this.getUsageSpec1() - usageAmount);
	}
	public void levelUpSpec2Att(float anAttack, float usageAmount)
	{
		this.setSpecial2Attack(this.getSpecial2Attack() + anAttack);
		this.setUsageSpec2(this.getUsageSpec2() - usageAmount);
	}
	public void levelUpSpec3Att(float anAttack, float usageAmount)
	{
		this.setSpecial3Attack(this.getSpecial3Attack() + anAttack);
		this.setUsageSpec3(this.getUsageSpec3() - usageAmount);
	}
	public void levelUpSpec4Att(float anAttack, float usageAmount)
	{
		this.setSpecial4Attack(this.getSpecial4Attack() + anAttack);
		this.setUsageSpec4(this.getUsageSpec4() - usageAmount);
	}
}