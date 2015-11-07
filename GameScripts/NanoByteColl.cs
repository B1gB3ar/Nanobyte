using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NanoByteColl : MonoBehaviour {

	string NanoBitString = "NanoBit";

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.name.Contains(NanoBitString) && !coll.gameObject.GetComponent<NanoBitIns>().nanobit.isMovingToAttack
		   && !coll.gameObject.GetComponent<NanoBitIns>().nanobit.isAttacking)
		{
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setContainment(true);
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.name.Contains(NanoBitString) && !coll.gameObject.GetComponent<NanoBitIns>().nanobit.isMovingToAttack)
		{
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.setContainment(false);
			coll.gameObject.GetComponent<NanoBitIns>().nanobit.resetFirstPass();
		}
	}

}
