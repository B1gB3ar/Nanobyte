using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayValues : MonoBehaviour {

	public CanvasGroup healthGroup;
	public bool displayHealth;
	public float counterHealth = 0;

	public CanvasGroup usageGroup;
	public bool displayUsage;
	public float counterUsage = 0;

	public float coolDown = 1.5f;
	public float coolDownCounter = 0;
	public Slider usageBar;

	public NanoByteIns nanoByte;

	public void displayHealthBar()
	{
		displayHealth = true;
		counterHealth = 0;
	}
	public void displayUsagebar()
	{
		displayUsage = true;
		counterUsage = 0;
	}

	void Update()
	{

		counterHealth += Time.deltaTime;
		counterUsage += Time.deltaTime;
		if(usageBar.value < usageBar.maxValue)
			coolDownCounter += Time.deltaTime;
		else 
			coolDownCounter = 0;
		if(displayHealth)
		{
			healthGroup.alpha = Mathf.Lerp(healthGroup.alpha, 1, Time.deltaTime * 1.5f);
			if(counterHealth >= 5)
			{
				displayHealth = false;
				counterHealth = 0;
			}
		}
		else
		{
			healthGroup.alpha = Mathf.Lerp(healthGroup.alpha, 0, Time.deltaTime * 2);
			if(counterHealth >= 5)
				counterHealth = 0;
		}
		if(displayUsage)
		{
			usageGroup.alpha = Mathf.Lerp(usageGroup.alpha, 1, Time.deltaTime * 1.5f);
		}
		else
		{
			usageGroup.alpha = Mathf.Lerp(usageGroup.alpha, 0, Time.deltaTime * 2);
			if(counterUsage >= 4)
				counterUsage = 0;
		}

		if(coolDownCounter >= coolDown)
		{
			nanoByte.nanoByte.setUsageAmount(Mathf.Lerp(usageBar.value, 100, Time.deltaTime * 2));
			nanoByte.nanoByte.updateUsage(usageBar);
		}
		if(usageBar.value > usageBar.maxValue - 0.1f)
		{
			displayUsage = false;
			usageBar.value = usageBar.maxValue;
			coolDownCounter = 0;
		}

	}

}
