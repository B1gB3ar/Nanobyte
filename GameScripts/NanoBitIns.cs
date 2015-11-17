using UnityEngine;
using System.Collections;

public class NanoBitIns : MonoBehaviour {

	public NanoBit nanobit;
	public NanoByteIns nanoByte;
	public float counterMovement = 0;
	public bool goRight;
	public bool moveOver;
	public Color changeColor;

	public Transform transformObject;

	void Awake()
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null)
			nanoByte = GameObject.FindGameObjectWithTag ("Player").GetComponent<NanoByteIns> ();
		else
			transformObject = transform;
	}

	void Update()
	{
		counterMovement += Time.deltaTime;
		//TODO FIX THIS AWFUL LOOKING CODE
		if(nanobit.isMovingToAttack && nanobit.isSelected)
		{
			Debug.Log("Attacking from selection");
			nanobit.moveToAttack(transform, nanobit.getEnemyPos());
			/*if(moveOver)
			{
				if(goRight)
				{
					//TODO FIX THIS! NOT WORKING CORRECTLY...
					Debug.Log("Right: " + nanobit.getLocation());
					nanobit.setLocation(Vector2.Lerp(nanobit.getLocation(), 
					                                 new Vector2(nanobit.getLocation().x + 5000, nanobit.getLocation().y),
					                                 Time.deltaTime * 3));
				}
				else
				{
					//TODO FIX THIS! NOT WORKING CORRECTLY...
					Debug.Log("Left: " + nanobit.getLocation());
					nanobit.setLocation(Vector2.Lerp(nanobit.getLocation(), 
					                                 new Vector2(nanobit.getLocation().x - 5000, nanobit.getLocation().y),
					                                 Time.deltaTime * 3));
				}
			}*/
			Vector3 dir = nanobit.getEnemyPos().position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 270;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
				nanobit.charMovement(transform, 0.2f, 5);
				counterMovement = 0;
			}
		}
		else if(nanobit.isMovingToAttack)
		{
			Debug.Log("Moving to Attack");
			nanobit.moveToAttack(transform, nanobit.getEnemyPos());
			Vector3 dir = nanobit.getEnemyPos().position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 270;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		else if(nanobit.isAttacking)
		{
			//TODO
			Debug.Log("Attacking");
		}
		else if(!nanobit.isSelected && !nanobit.containedWithByte)
		{
			if(nanoByte != null)
				nanobit.moveBack(transform, nanoByte.transform);
			else
				nanobit.moveBack(transform, transformObject);
		}
	}
}
