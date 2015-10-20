using UnityEngine;
using System.Collections;

public class NanoBitIns : MonoBehaviour {

	public NanoBit nanobit;

	void Update()
	{
		if(nanobit.isSelected)
			nanobit.stopNanoBitMovement();
		else if(nanobit.containedWithByte)
			nanobit.nanoBitMovement(transform);
		else
			nanobit.nanoBitMoveBack(transform);

	}

}
