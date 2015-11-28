using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveBackground : MonoBehaviour {

	public GameObject backgroundInitial;
	public GameObject backgroundFinal;
	public GameObject background2;

	public bool move;
	
	// Update is called once per frame
	void Update () 
	{

		if(move)
		{
			background2.GetComponent<RectTransform>().localPosition = 
				backgroundInitial.GetComponent<RectTransform>().localPosition;
			if(background2.GetComponent<RectTransform>().localPosition.y <= 
			   backgroundInitial.GetComponent<RectTransform>().localPosition.y)
			{
				move = false;
			}
		}
		else
		{
			background2.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
				background2.GetComponent<RectTransform>().localPosition, 
				backgroundFinal.GetComponent<RectTransform>().localPosition, Time.deltaTime * 0.05f);
			if(background2.GetComponent<RectTransform>().localPosition.y <= 
			   backgroundFinal.GetComponent<RectTransform>().localPosition.y + 120f)
			{
				move = true;
			}
		}
	}
}
