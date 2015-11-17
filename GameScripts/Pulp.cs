using UnityEngine;
using System.Collections;

public class Pulp : MonoBehaviour {

	public Enemy pulpEnemy;

	void Awake()
	{
		pulpEnemy = new Enemy(50, 0, transform.position);
	}

	public void attackedPulp()
	{
		//TODO
		// Shake the pulp I guess
		// Decrement health
	}

	public void destroyedPulp()
	{
		//TODO
		// Burst into red blood cells
		// This means we need to first instantiate the redBloodCells, then shoot them in different directions
	}

}
