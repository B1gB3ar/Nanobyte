using UnityEngine;
using System.Collections;

public class RedBloodCell : MonoBehaviour {

	public Enemy redBloodCellEnemy;

	void Awake()
	{
		redBloodCellEnemy = new Enemy(0, 0, transform.position);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			// Make the red blood cell disappear
			// This is a collectible, so we will make it disappear then add however many points to our expPoints
		}
	}

}
