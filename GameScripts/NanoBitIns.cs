using UnityEngine;
using System.Collections;

public class NanoBitIns : MonoBehaviour {

	public NanoBit nanobit;
	public float counterMovement = 0;

	void Update()
	{
		counterMovement += Time.deltaTime;

		if(nanobit.isSelected)
				nanobit.stopNanoBitMovement();
		else if(nanobit.containedWithByte)
		{
			if(counterMovement >= 0.1f)
			{
				nanobit.nanoBitMovement(transform);
				counterMovement = 0;
			}
		}
		else
			nanobit.nanoBitMoveBack(transform);

	}

}
