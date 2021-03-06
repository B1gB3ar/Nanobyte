﻿using UnityEngine;
using System.Collections;

public class SelectCollider : MonoBehaviour {

	public Select select;

	void OnTriggerEnter2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString))
		{
			//coll.gameObject.GetComponent<NanoBitIns>().nanobit.stopNanoBitMovement();
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setSelection(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString) && select.selector.sizeDelta != Vector2.zero)
		{
			//coll.gameObject.GetComponent<NanoBitIns>().nanobit.nanoBitMovement(coll.gameObject.transform, 1);
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setSelection(false);
		}

	}

}
