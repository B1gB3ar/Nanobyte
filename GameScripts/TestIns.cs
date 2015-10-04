using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TestIns : MonoBehaviour {

	public NanoByte nanoBit;

	public Animator nanoAnim;
	public static int LENGTH = 7;
	public static Text[] children = new Text[7];

	// Use this for initialization
	void Awake () {

		children = GameObject.FindGameObjectWithTag("Display").GetComponentsInChildren<Text>();
		Debug.Log(children.Length);

		if(children.Length == 5)
		{

			children[0].GetComponent<Text>().text = nanoBit.attackValues.getSpecial4Attack().ToString();
			children[1].GetComponent<Text>().text = nanoBit.attackValues.getSpecial3Attack().ToString();
			children[2].GetComponent<Text>().text = nanoBit.attackValues.getSpecial2Attack().ToString();
			children[3].GetComponent<Text>().text = nanoBit.attackValues.getSpecial1Attack().ToString();
			children[4].GetComponent<Text>().text = nanoBit.attackValues.getStandardAttack().ToString();
			children[5].GetComponent<Text>().text = nanoBit.attackValues.getStandardAttack().ToString();
			children[6].GetComponent<Text>().text = nanoBit.attackValues.getStandardAttack().ToString();

		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * nanoBit.getSpeed() * Time.deltaTime;
		nanoAnim.SetFloat ("Speed", Mathf.Abs(move.x + move.y));
	
	}

	//(COMPLETED) Use parameter to get which button was clicked and pass that in as a parameter so we can
	// just have one method instead of all of these
	public void clickedALevelChanger(Button button)
	{
		Debug.Log(button.name.Split('-')[1]);

		nanoBit.attackValues.setAttackBasedOnString(button.name.Split('-')[1], int.Parse(button.name.Split('-')[0]));

	}

}
