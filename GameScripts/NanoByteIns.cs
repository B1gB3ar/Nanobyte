using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NanoByteIns : MonoBehaviour {

	public GameObject nanoByteGameObject;
	public NanoByte nanoByte;
	public List<NanoBit> nanoBits = new List<NanoBit>();
	public List<GameObject> holderForBits = new List<GameObject>();
	public Animator nanoAnim;
	public Slider healthBar;
	public Slider usageBar;

	public int nanoBitNumber;

	public float counter = 0f;
	Vector3 lastMove = Vector3.zero;
	Vector3 move = Vector3.zero;

	// Use this for initialization
	void Awake () {
		nanoByte = new NanoByte();
		nanoByte.setLocation(nanoByteGameObject.transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * nanoByte.getSpeed() * Time.deltaTime;
		if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
		{
			float heading = Mathf.Atan2(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			transform.rotation = Quaternion.Euler(0f,0f,heading * Mathf.Rad2Deg);
		}
		if(lastMove != move)
			nanoByte.setLocation(nanoByteGameObject.transform.position);
		//nanoAnim.SetFloat ("Speed", Mathf.Abs(move.x + move.y));
		lastMove = move;

	}

	void Update()
	{
		if(holderForBits.Count <= 25)
		{
			counter += Time.deltaTime;
			if(counter >= 10.0f)
			{
				GameObject nanoBitInst = Instantiate(Resources.Load("NanoBit") as GameObject);
				nanoBits.Add(nanoBitInst.GetComponent<NanoBitIns>().nanobit);
				nanoByte.spawn(nanoBitInst, nanoByte, holderForBits);
				counter = 0.0f;

			}
		}

	}

	public void damagePlayer(int damage)
	{
		nanoByte.inflictDamage(damage);
		nanoByte.updateHealth(healthBar);
	}
	
}
