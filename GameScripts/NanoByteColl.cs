using UnityEngine;
using System.Collections;

public class NanoByteColl : MonoBehaviour {

	void OnTriggerExit2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString))
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setContainment(false);
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		string NanoBitString = "NanoBit";
		if(coll.gameObject.name.Contains(NanoBitString))
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setContainment(true);
		
	}

}
