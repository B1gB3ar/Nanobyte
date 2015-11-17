using UnityEngine;
using System.Collections;

public class WhiteBloodCell : MonoBehaviour {

	public Enemy redBloodCellEnemy;
	
	void Awake()
	{
		redBloodCellEnemy = new Enemy(150, 10, transform.position);
	}

	//TODO We may want to see which way the enemy is facing so as we don't just attack the nanobits when we 
	// come into contact with the enemy
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.tag = "Player";
			// Use the damagePlayer for the Player
		}
		else if(coll.gameObject.tag == "NanoBit")
		{
			coll.gameObject.tag = "NanoBit";
			// Use the inflictDamage for the NanoBit 
		}
		//Maybe include some knockback
		//If you include knockback, be sure to set the boolean for the nanobit to be back to movingToAttack
		// instead of attacking
	}

}
