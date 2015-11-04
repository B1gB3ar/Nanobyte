using UnityEngine;
using System.Collections;

public class NanoBitIns : MonoBehaviour {

	public NanoBit nanobit;
	public float counterMovement = 0;

	void Update()
	{
		counterMovement += Time.deltaTime;

		if(nanobit.isAttacking && nanobit.isSelected)
		{
			Debug.Log("Attacking from selection");
			nanobit.moveToAttack(transform, nanobit.getEnemyPos());
		}

		if(nanobit.isSelected)
		{
			Debug.Log("Is Selected");
			nanobit.stopNanoBitMovement();
		}
		else if(nanobit.containedWithByte)
		{
			Debug.Log("Contained within Byte");
			if(counterMovement >= 0.1f)
			{
				nanobit.nanoBitMovement(transform);
				counterMovement = 0;
			}
		}
		else if(nanobit.isAttacking)
		{
			Debug.Log("Attacking");
			nanobit.moveToAttack(transform, nanobit.getEnemyPos());
		}
		else if(!nanobit.isSelected && !nanobit.containedWithByte)
		{
			Debug.Log("Not selected or contained, moving back");
			nanobit.nanoBitMoveBack(transform);
		}
	}
}
