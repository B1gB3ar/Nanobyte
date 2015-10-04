using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackValues
{

	public NanoByte nanoByte = new NanoByte();
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

	public void setAttackBasedOnString(string buttonName, int index)
	{
		
		switch(buttonName)
		{
		case "LvlUStdAtt":
			this.setStandardAttack(this.getStandardAttack() + 1);
			TestIns.children[index].text = this.getStandardAttack().ToString();
			break;
		case "LvlDStdAtt":
			if(this.getStandardAttack() > 0)
				this.setStandardAttack(this.getStandardAttack() - 1);
			TestIns.children[index].text = this.getStandardAttack().ToString();
			break;
		case "LvlUSp1":
			this.setSpecial1Attack(this.getSpecial1Attack() + 1);
			TestIns.children[index].text = this.getSpecial1Attack().ToString();
			break;
		case "LvlDSp1":
			if(this.getSpecial1Attack() > 0)
				this.setSpecial1Attack(this.getSpecial1Attack() - 1);
			TestIns.children[index].text = this.getSpecial1Attack().ToString();
			break;
		case "LvlUSp2":
			this.setSpecial2Attack(this.getSpecial2Attack() + 1);
			TestIns.children[index].text = this.getSpecial2Attack().ToString();
			break;
		case "LvlDSp2":
			if(this.getSpecial2Attack() > 0)
				this.setSpecial2Attack(this.getSpecial2Attack() - 1);
			TestIns.children[index].text = this.getSpecial2Attack().ToString();
			break;
		case "LvlUSp3":
			this.setSpecial3Attack(this.getSpecial3Attack() + 1);
			TestIns.children[index].text = this.getSpecial3Attack().ToString();
			break;
		case "LvlDSp3":
			if(this.getSpecial3Attack() > 0)
				this.setSpecial3Attack(this.getSpecial3Attack() - 1);
			TestIns.children[index].text = this.getSpecial3Attack().ToString();
			break;
		case "LvlUSp4":
			this.setSpecial4Attack(this.getSpecial4Attack() + 1);
			TestIns.children[index].text = this.getSpecial4Attack().ToString();
			break;
		case "LvlDSp4":
			if(this.getSpecial4Attack() > 0)
				this.setSpecial4Attack(this.getSpecial4Attack() - 1);
			TestIns.children[index].text = this.getSpecial4Attack().ToString();
			break;
		case "LvlDHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() - 1);
			TestIns.children[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlUHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() + 1);
			TestIns.children[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlDSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() - 1);
			TestIns.children[index].text = nanoByte.getSpeed().ToString();
			break;
		case "LvlUSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() + 1);
			TestIns.children[index].text = nanoByte.getSpeed().ToString();
			break;
		default:
			Debug.Log("Error!!");
			break;
			
			
		}
		
	}

}

