using UnityEngine;
using System.Collections;

public class SpecialAttackKeys : MonoBehaviour {

	public NanoByteIns nanoByte;
	public DisplayValues displayValues;

	//TODO Change these to when a button is clicked, alpha keys will be used to select a portion of the nanobits
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(nanoByte.nanoByte.getUsageAmount() > nanoByte.nanoByte.attackValues.getUsageSpec1())
			{
				nanoByte.nanoByte.decrementUsageBarBySpec1();
				nanoByte.nanoByte.updateUsage(nanoByte.usageBar);
				displayValues.coolDownCounter = 0;
			}
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			if(nanoByte.nanoByte.getUsageAmount() > nanoByte.nanoByte.attackValues.getUsageSpec2())
			{
				nanoByte.nanoByte.decrementUsageBarBySpec2();
				nanoByte.nanoByte.updateUsage(nanoByte.usageBar);
				displayValues.coolDownCounter = 0;
			}
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(nanoByte.nanoByte.getUsageAmount() > nanoByte.nanoByte.attackValues.getUsageSpec3())
			{
				nanoByte.nanoByte.decrementUsageBarBySpec3();
				nanoByte.nanoByte.updateUsage(nanoByte.usageBar);
				displayValues.coolDownCounter = 0;
			}
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(nanoByte.nanoByte.getUsageAmount() > nanoByte.nanoByte.attackValues.getUsageSpec4())
			{
				nanoByte.nanoByte.decrementUsageBarBySpec4();
				nanoByte.nanoByte.updateUsage(nanoByte.usageBar);
				displayValues.coolDownCounter = 0;
			}
		}
	}
}
