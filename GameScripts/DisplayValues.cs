using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayValues : MonoBehaviour {

	//public CanvasGroup healthGroup;
	public bool displayHealth;
	public float counterHealth = 0;

	public float coolDown = 1.5f;
	public float coolDownCounter = 0;

	public NanoByteIns nanoByte;

	public void displayHealthBar()
	{
		displayHealth = true;
		counterHealth = 0;
	}

	void Update()
	{

		counterHealth += Time.deltaTime;
		if(displayHealth)
		{
			//healthGroup.alpha = Mathf.Lerp(healthGroup.alpha, 1, Time.deltaTime * 1.5f);
			if(counterHealth >= 5)
			{
				displayHealth = false;
				counterHealth = 0;
			}
		}
		else
		{
			//healthGroup.alpha = Mathf.Lerp(healthGroup.alpha, 0, Time.deltaTime * 2);
			if(counterHealth >= 5)
				counterHealth = 0;
		}

		if(coolDownCounter >= coolDown)
		{
			//nanoByte.nanoByte.setUsageAmount(Mathf.Lerp(usageBar.value, 100, Time.deltaTime * 2));
			//nanoByte.nanoByte.updateUsage(usageBar);
		}
		/*if(usageBar.value > usageBar.maxValue - 0.1f)
		{
			displayUsage = false;
			usageBar.value = usageBar.maxValue;
			coolDownCounter = 0;
		}*/

	}

}
