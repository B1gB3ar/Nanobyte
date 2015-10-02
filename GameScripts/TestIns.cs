using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestIns : MonoBehaviour {

	public NanoByte nanoBit;
	public Animator nanoAnim;

	public Text displayStdAtt;
	public Text displaySpec1;
	public Text displaySpec2;
	public Text displaySpec3;
	public Text displaySpec4;

	// Use this for initialization
	void Awake () {
	
		displayStdAtt.text = nanoBit.attackValues.getStandardAttack().ToString();
		displaySpec1.text = nanoBit.attackValues.getSpecial1Attack().ToString();
		displaySpec2.text = nanoBit.attackValues.getSpecial2Attack().ToString();
		displaySpec3.text = nanoBit.attackValues.getSpecial3Attack().ToString();
		displaySpec4.text = nanoBit.attackValues.getSpecial4Attack().ToString();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * nanoBit.getSpeed() * Time.deltaTime;
		nanoAnim.SetFloat ("Speed", Mathf.Abs(move.x + move.y));
	
	}

	//TODO Use parameter to get which button was clicked and pass that in as a parameter so we can
	// just have one method instead of all of these
	public void clickedALevelChanger(Button button)
	{

		setAttackBasedOnString(button.name);

	}

	public void setAttackBasedOnString(string buttonName)
	{
		
		switch(buttonName)
		{
		case "LvlUStdAtt":
			nanoBit.attackValues.setStandardAttack(nanoBit.attackValues.getStandardAttack() + 1);
			displayStdAtt.text = nanoBit.attackValues.getStandardAttack().ToString();
			break;
		case "LvlDStdAtt":
			if(nanoBit.attackValues.getStandardAttack() > 0)
				nanoBit.attackValues.setStandardAttack(nanoBit.attackValues.getStandardAttack() - 1);
			displayStdAtt.text = nanoBit.attackValues.getStandardAttack().ToString();
			break;
		case "LvlUSp1":
			nanoBit.attackValues.setSpecial1Attack(nanoBit.attackValues.getSpecial1Attack() + 1);
			displaySpec1.text = nanoBit.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlDSp1":
			if(nanoBit.attackValues.getSpecial1Attack() > 0)
				nanoBit.attackValues.setSpecial1Attack(nanoBit.attackValues.getSpecial1Attack() - 1);
			displaySpec1.text = nanoBit.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlUSp2":
			nanoBit.attackValues.setSpecial2Attack(nanoBit.attackValues.getSpecial2Attack() + 1);
			displaySpec2.text = nanoBit.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlDSp2":
			if(nanoBit.attackValues.getSpecial2Attack() > 0)
				nanoBit.attackValues.setSpecial2Attack(nanoBit.attackValues.getSpecial2Attack() - 1);
			displaySpec2.text = nanoBit.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlUSp3":
			nanoBit.attackValues.setSpecial3Attack(nanoBit.attackValues.getSpecial3Attack() + 1);
			displaySpec3.text = nanoBit.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlDSp3":
			if(nanoBit.attackValues.getSpecial3Attack() > 0)
				nanoBit.attackValues.setSpecial3Attack(nanoBit.attackValues.getSpecial3Attack() - 1);
			displaySpec3.text = nanoBit.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlUSp4":
			nanoBit.attackValues.setSpecial4Attack(nanoBit.attackValues.getSpecial4Attack() + 1);
			displaySpec4.text = nanoBit.attackValues.getSpecial4Attack().ToString();
			break;
		case "LvlDSp4":
			if(nanoBit.attackValues.getSpecial4Attack() > 0)
				nanoBit.attackValues.setSpecial4Attack(nanoBit.attackValues.getSpecial4Attack() - 1);
			displaySpec4.text = nanoBit.attackValues.getSpecial4Attack().ToString();
			break;
		default:
			Debug.Log("Error!!");
			break;
			
			
		}
		
	}
	/*
	public void levelUpAttackStandard()
	{

		nanoBit.attackValues.setStandardAttack(nanoBit.attackValues.getStandardAttack() + 1);
		displayStdAtt.text = nanoBit.attackValues.getStandardAttack().ToString();

	}
	public void levelDownAttackStandard()
	{
		if(nanoBit.attackValues.getStandardAttack() > 0)
			nanoBit.attackValues.setStandardAttack(nanoBit.attackValues.getStandardAttack() - 1);
		displayStdAtt.text = nanoBit.attackValues.getStandardAttack().ToString();
		
	}
	public void levelUpAttackSpec1()
	{
		
		nanoBit.attackValues.setSpecial1Attack(nanoBit.attackValues.getSpecial1Attack() + 1);
		displaySpec1.text = nanoBit.attackValues.getSpecial1Attack().ToString();
		
	}
	public void levelDownAttackSpec1()
	{
		if(nanoBit.attackValues.getSpecial1Attack() > 0)
			nanoBit.attackValues.setSpecial1Attack(nanoBit.attackValues.getStandardAttack() - 1);
		displaySpec1.text = nanoBit.attackValues.getSpecial1Attack().ToString();
		
	}
	public void levelUpAttackSpec2()
	{
		
		nanoBit.attackValues.setSpecial2Attack(nanoBit.attackValues.getSpecial2Attack() + 1);
		displaySpec2.text = nanoBit.attackValues.getSpecial2Attack().ToString();
		
	}
	public void levelDownAttackSpec2()
	{
		if(nanoBit.attackValues.getSpecial2Attack() > 0)
			nanoBit.attackValues.setSpecial2Attack(nanoBit.attackValues.getSpecial2Attack() - 1);
		displaySpec2.text = nanoBit.attackValues.getSpecial2Attack().ToString();
		
	}
	public void levelUpAttackSpec3()
	{
		
		nanoBit.attackValues.setSpecial3Attack(nanoBit.attackValues.getSpecial3Attack() + 1);
		displaySpec3.text = nanoBit.attackValues.getSpecial3Attack().ToString();
		
	}
	public void levelDownAttackSpec3()
	{
		if(nanoBit.attackValues.getSpecial3Attack() > 0)
			nanoBit.attackValues.setSpecial3Attack(nanoBit.attackValues.getSpecial3Attack() - 1);
		displaySpec3.text = nanoBit.attackValues.getSpecial3Attack().ToString();
		
	}
	public void levelUpAttackSpec4()
	{
		
		nanoBit.attackValues.setSpecial2Attack(nanoBit.attackValues.getSpecial4Attack() + 1);
		displaySpec4.text = nanoBit.attackValues.getSpecial4Attack().ToString();
		
	}
	public void levelDownAttackSpec4()
	{
		if(nanoBit.attackValues.getSpecial4Attack() > 0)
			nanoBit.attackValues.setSpecial4Attack(nanoBit.attackValues.getSpecial4Attack() - 1);
		displaySpec4.text = nanoBit.attackValues.getSpecial4Attack().ToString();
		
	}*/


}
