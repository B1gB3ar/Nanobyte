using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackValues
{

	public int dmg_StandardAttack;
	public int dmg_Special1;
	public int dmg_Special2;
	public int dmg_Special3;
	public int dmg_Special4;

	public AttackValues()
	{

		dmg_StandardAttack = 5;
		dmg_Special1 = 0;
		dmg_Special2 = 0;
		dmg_Special3 = 0;
		dmg_Special4 = 0;

	}

	public AttackValues(int stdAtt, int spec1, int spec2, int spec3, int spec4)
	{

		setStandardAttack(stdAtt);
		setSpecial1Attack(spec1);
		setSpecial2Attack(spec2);
		setSpecial3Attack(spec3);
		setSpecial4Attack(spec4);

	}

	/*
	 * 
	 * TODO This can be setup to change the attacks through buttons
	 * 
	**/ 
	public void setStandardAttack(int stdAtt)
	{

		dmg_StandardAttack = stdAtt;

	}
	public void setSpecial1Attack(int spec1)
	{

		dmg_Special1 = spec1;

	}
	public void setSpecial2Attack(int spec2)
	{
		
		dmg_Special2 = spec2;
		
	}
	public void setSpecial3Attack(int spec3)
	{
		
		dmg_Special3 = spec3;
		
	}
	public void setSpecial4Attack(int spec4)
	{
		
		dmg_Special4 = spec4;
		
	}

	public int getStandardAttack()
	{

		return dmg_StandardAttack;

	}
	public int getSpecial1Attack()
	{

		return dmg_Special1;

	}
	public int getSpecial2Attack()
	{
		
		return dmg_Special2;
		
	}
	public int getSpecial3Attack()
	{
		
		return dmg_Special3;
		
	}
	public int getSpecial4Attack()
	{
		
		return dmg_Special4;
		
	}

}

