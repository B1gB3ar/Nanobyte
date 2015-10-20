using UnityEngine;
using System.Collections;

public class SelectCollider : MonoBehaviour {

	public Select select;

	void OnTriggerEnter2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString))
		{
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.stopNanoBitMovement();
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setSelection(true);
			Debug.Log("Selected " + coll.gameObject.name);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString) && select.selector.sizeDelta != Vector2.zero)
		{
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.nanoBitMovement(coll.gameObject.transform);
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setSelection(false);
			Debug.Log("Deselected " + coll.gameObject.name);
		}

	}

}
