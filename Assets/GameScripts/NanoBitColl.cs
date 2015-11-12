using UnityEngine;
using System.Collections;

public class NanoBitColl : MonoBehaviour {

	public NanoBitIns nanoBit;

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.tag == "nanoBit" && nanoBit.nanobit.getMoveToAttack() && coll.name != name)
		{	
			Debug.Log("Found nanoBit in front of current nanoBit...");
			nanoBit.moveOver = true;
		}
		else if(coll.tag == "Enemy_Static" && nanoBit.nanobit.getMoveToAttack())
		{
			nanoBit.nanobit.setMoveToAttack(false);
			nanoBit.nanobit.isAttacking = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "nanoBit" && coll.GetComponent<NanoBitIns>().nanobit.getMoveToAttack())
		{
			nanoBit.goRight = !nanoBit.goRight;
			nanoBit.moveOver = false;
		}
		nanoBit.nanobit.resetFirstPass();
	}
}
