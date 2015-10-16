using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TestIns : MonoBehaviour {

	public GameObject nanoByteGameObject;
	public NanoByte nanoByte;
	public List<NanoBit> nanoBits = new List<NanoBit>();
	public List<GameObject> holderForBits = new List<GameObject>();
	public Animator nanoAnim;
	public static int LENGTH = 7;
	public static Text[] children = new Text[LENGTH];

	public float counter = 0f;
	Vector3 lastMove = Vector3.zero;
	Vector3 move = Vector3.zero;

	// Use this for initialization
	void Awake () {
		nanoByte = new NanoByte();
		children = GameObject.FindGameObjectWithTag("Display").GetComponentsInChildren<Text>();
		Debug.Log(children.Length);
		
		if(children.Length == 7)
		{

			children[0].GetComponent<Text>().text = nanoByte.getHealth().ToString();
			children[1].GetComponent<Text>().text = nanoByte.getSpeed().ToString();
			children[2].GetComponent<Text>().text = nanoByte.attackValues.getStandardAttack().ToString();
			children[3].GetComponent<Text>().text = nanoByte.attackValues.getSpecial1Attack().ToString();
			children[4].GetComponent<Text>().text = nanoByte.attackValues.getSpecial2Attack().ToString();
			children[5].GetComponent<Text>().text = nanoByte.attackValues.getSpecial3Attack().ToString();
			children[6].GetComponent<Text>().text = nanoByte.attackValues.getSpecial4Attack().ToString();

		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(lastMove != move)
			nanoByte.setLocation(nanoByteGameObject.transform.position);

		move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * nanoByte.getSpeed() * Time.deltaTime;
		nanoAnim.SetFloat ("Speed", Mathf.Abs(move.x + move.y));
		lastMove = move;

	}

	void Update()
	{

		counter += Time.deltaTime;
		if(counter >= 10.0f && holderForBits.Count < 25)
		{
			spawnNanoBit();
			counter = 0.0f;

		}

	}

	public void spawnNanoBit()
	{

		GameObject nanoBot = Instantiate(Resources.Load("NanoBit") as GameObject);
		Debug.Log(nanoByte.getLocation());
		nanoBot.transform.position = nanoByte.getLocation();
		holderForBits.Add(nanoBot);
		Debug.Log(holderForBits.Count);

	}
	
	//(COMPLETED) Use parameter to get which button was clicked and pass that in as a parameter so we can
	// just have one method instead of all of these
	public void clickedALevelChanger(Button button)
	{
		Debug.Log(button.name.Split('-')[1]);
		
		this.setAttackBasedOnString(button.name.Split('-')[1], int.Parse(button.name.Split('-')[0]));
		
	}

	public void setAttackBasedOnString(string buttonName, int index)
	{
		
		switch(buttonName)
		{
		case "LvlUStdAtt":
			nanoByte.attackValues.setStandardAttack(nanoByte.attackValues.getStandardAttack() + 1);
			TestIns.children[index].text = nanoByte.attackValues.getStandardAttack().ToString();
			break;
		case "LvlDStdAtt":
			if(nanoByte.attackValues.getStandardAttack() > 0)
				nanoByte.attackValues.setStandardAttack(nanoByte.attackValues.getStandardAttack() - 1);
			TestIns.children[index].text = nanoByte.attackValues.getStandardAttack().ToString();
			break;
		case "LvlUSp1":
			nanoByte.attackValues.setSpecial1Attack(nanoByte.attackValues.getSpecial1Attack() + 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlDSp1":
			if(nanoByte.attackValues.getSpecial1Attack() > 0)
				nanoByte.attackValues.setSpecial1Attack(nanoByte.attackValues.getSpecial1Attack() - 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlUSp2":
			nanoByte.attackValues.setSpecial2Attack(nanoByte.attackValues.getSpecial2Attack() + 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlDSp2":
			if(nanoByte.attackValues.getSpecial2Attack() > 0)
				nanoByte.attackValues.setSpecial2Attack(nanoByte.attackValues.getSpecial2Attack() - 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlUSp3":
			nanoByte.attackValues.setSpecial3Attack(nanoByte.attackValues.getSpecial3Attack() + 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlDSp3":
			if(nanoByte.attackValues.getSpecial3Attack() > 0)
				nanoByte.attackValues.setSpecial3Attack(nanoByte.attackValues.getSpecial3Attack() - 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlUSp4":
			nanoByte.attackValues.setSpecial4Attack(nanoByte.attackValues.getSpecial4Attack() + 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial4Attack().ToString();
			break;
		case "LvlDSp4":
			if(nanoByte.attackValues.getSpecial4Attack() > 0)
				nanoByte.attackValues.setSpecial4Attack(nanoByte.attackValues.getSpecial4Attack() - 1);
			TestIns.children[index].text = nanoByte.attackValues.getSpecial4Attack().ToString();
			break;
		case "LvlDHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() - 1);
			TestIns.children[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlUHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() + 1);
			TestIns.children[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlDSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() - 1.0f);
			TestIns.children[index].text = nanoByte.getSpeed().ToString();
			break;
		case "LvlUSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() + 1.0f);
			TestIns.children[index].text = nanoByte.getSpeed().ToString();
			break;
		default:
			Debug.Log("Error!!");
			break;
			
		}
		
	}
	
}
