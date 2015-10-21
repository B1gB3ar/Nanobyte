using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {

	public bool display;
	public float counter = 0;

	public void displayHealthBar()
	{
		display = true;
		counter = 0;
	}

	void Update()
	{

		counter += Time.deltaTime;
		if(display)
		{
			GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, 1, Time.deltaTime * 1.5f);
			if(counter >= 5)
			{
				display = false;
				counter = 0;
			}
		}
		else
		{
			GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, 0, Time.deltaTime * 2);
		}

		if(counter >= 5)
		{
			counter = 0;
		}

	}

}
