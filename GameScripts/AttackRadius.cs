using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AttackRadius : MonoBehaviour {

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
			nanoByte.nanoBits[i].isMovingToAttack = false;
			nanoByte.nanoBits[i].isAttacking = false;
			nanoByte.nanoBits[i].setSelection(false);
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.tag == "Enemy")
		{	
			foreach(NanoBit nanoBit in nanoByte.nanoBits)
			{
				if(!nanoBit.getSelection())
				{
					nanoBit.isMovingToAttack = true;
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
					Debug.Log("Leaving Enemy");
					nanoBit.isMovingToAttack = false;
					nanoBit.isAttacking = false;
					nanoBit.setEnemyPos(null);
					nanoBit.firstPass = true;
					nanoBit.randNumb = Random.Range(1, 9);
				}
			}
		}
	}

}
