using UnityEngine;
using System.Collections;

public class OuterPulp : MonoBehaviour {

	public Enemy outerPulpEnemy;

	void Awake()
	{
		outerPulpEnemy = new Enemy(120, 0, transform.position);
	}

	public void attackedOuterPulp()
	{
		//TODO
		//Possibly lower opacity based on our health value
	}
	
	public void destroyedOuterPulp()
	{
		//TODO
		//Opacity should be completely zero here, or maybe we want to play a destroy animation
	}
}
