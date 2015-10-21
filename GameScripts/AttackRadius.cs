using UnityEngine;
using System.Collections;

public class AttackRadius : MonoBehaviour {

	public NanoByteIns nanoByte;

	// TODO Not working properly just yet..
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Enemy")
		{
			foreach(NanoBit nanoBit in nanoByte.nanoBits)
			{
				if(!nanoBit.getSelection())
				{
					nanoBit.moveToAttack();
					nanoBit.setContainment(false);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "Enemy")
		{
			foreach(NanoBit nanoBit in nanoByte.nanoBits)
			{
				if(!nanoBit.getSelection())
					nanoBit.setContainment(true);
			}
		}
	}

}
