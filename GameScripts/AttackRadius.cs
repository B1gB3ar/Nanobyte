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
			//Debug.Log("Selected?: " + nanoByteInspector.nanoBits[i].isSelected);
			nanoByte.nanoBits[i].setContainment(false);
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
					nanoBit.isAttacking = true;
					nanoBit.setContainment(false);
					nanoBit.setEnemyPos(coll.transform);
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
				{
					nanoBit.isAttacking = false;
					nanoBit.setEnemyPos(null);
				}
			}
		}
	}

}
