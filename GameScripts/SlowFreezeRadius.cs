using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlowFreezeRadius : MonoBehaviour {

	public NanoByteIns nanoByte;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			CallBack();
		}
	}

	public void CallBack()
	{
		for(int i = 0; i < nanoByte.nanoBits.Count; ++i)
		{
			nanoByte.nanoBits[i].setContainment(false);
			nanoByte.nanoBits[i].setSelection(false);
			nanoByte.nanoBits[i].resetAttackSequence();
		}
	}

	//TODO Change these so that they slow the enemy down, not attack
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.tag == "Enemy")
		{	
			foreach(NanoBit nanoBit in nanoByte.nanoBits)
			{
				if(!nanoBit.getSelection())
				{
					Debug.Log("Enemy");
					nanoBit.setMoveToAttack(true);
					nanoBit.setContainment(false);
					nanoBit.setEnemyPos(coll.transform);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag.Contains("NanoBit"))
		{
			foreach(NanoBit nanoBit in nanoByte.nanoBits)
			{
				if(!nanoBit.getSelection())
				{
					//Debug.Log("Leaving Enemy");
					//nanoBit.resetAttackSequence();
					nanoBit.resetFirstPass();
				}
			}
		}
	}

}
