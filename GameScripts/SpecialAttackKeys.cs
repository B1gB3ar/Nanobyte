using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecialAttackKeys : MonoBehaviour {

	public NanoByteIns nanoByte;
	public DisplayValues displayValues;
	AttackValues attackVals;

	public bool allowedLasers = true;
	public bool allowedFlash = true;
	public bool allowedStealth = true;

	public Image lasersImage;
	public Image flashImage;
	public Image stealthImage;

	public float laserTime;
	public float stealthTime;

	public float laserDecrement;
	public float flashDecrement;
	public float stealthDecrement;

	void Awake()
	{
		attackVals = nanoByte.nanoByte.attackValues;
		laserDecrement = attackVals.getUsage_Lasers() / attackVals.getDecrement_Lasers();
		flashDecrement = attackVals.getDecrement_Flash();
		stealthDecrement = attackVals.getUsage_Stealth() / attackVals.getDecrement_Stealth();
	}

	public void updateAttacks()
	{
		laserDecrement = attackVals.getUsage_Lasers() / attackVals.getDecrement_Lasers();
		flashDecrement = attackVals.getDecrement_Flash();
		stealthDecrement = attackVals.getUsage_Stealth() / attackVals.getDecrement_Stealth();
	}

	//TODO Change these to when a button is clicked, alpha keys will be used to select a portion of the nanobits
	void Update () 
	{
		lasersImage.fillAmount = Mathf.Lerp(lasersImage.fillAmount, attackVals.getUsage_Lasers(), Time.deltaTime * 2);
		stealthImage.fillAmount = Mathf.Lerp(stealthImage.fillAmount, attackVals.getUsage_Stealth(), Time.deltaTime * 2);
		flashImage.fillAmount = Mathf.Lerp(flashImage.fillAmount, attackVals.getUsage_FlashFreeze(), Time.deltaTime * 2);
			
		if(Input.GetKey(KeyCode.E))
		{
			if(allowedLasers && attackVals.getUsage_Lasers() > 0)
			{
				Debug.Log("Firing Laser");
				//laserDecrement = attackVals.getUsage_Lasers() / attackVals.getDecrement_Lasers();
				attackVals.setUsage_Lasers(attackVals.getUsage_Lasers() - laserDecrement);  // Decrement by a value
			}
			else
			{
				Debug.Log("Not allowed to use Laser");
				//laserTime = 
			}
		}
		else if(Input.GetKeyDown(KeyCode.F))
		{
			if(allowedFlash)
			{
				Debug.Log("Flash Freeze");
				//flashDecrement = attackVals.getDecrement_Flash();
				attackVals.setUsage_FlashFreeze(attackVals.getUsage_FlashFreeze() - flashDecrement); // Decrement by a value
			}
			else
			{
				Debug.Log("Not allowed to use Flash");
				//Time = 
			}
		}
		/*else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(nanoByte.nanoByte.getUsageAmount() > nanoByte.nanoByte.attackValues.getUsage_SlowFreeze())
			{
				nanoByte.nanoByte.decrementUsageBarBySpec3();
				nanoByte.nanoByte.updateUsage(nanoByte.usageBar);
				displayValues.coolDownCounter = 0;
			}
		}*/
		else if(Input.GetKey(KeyCode.X))
		{
			if(allowedStealth)
			{
				Debug.Log("Stealth Mode");
				//stealthDecrement = attackVals.getUsage_Stealth() / attackVals.getDecrement_Stealth();
				attackVals.setUsage_Stealth(attackVals.getUsage_Stealth() - stealthDecrement);  // Decrement by a value
			}
			else
			{
				Debug.Log("Not allowed to use Stealth");
				//Time = 
			}
		}
	}
}
