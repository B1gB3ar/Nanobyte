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
	//public const int LENGTH = 7;
	//public Text[] displayStats = new Text[LENGTH];
	public Slider healthBar;

	public int nanoBitNumber;

	public float counter = 0f;
	Vector3 lastMove = Vector3.zero;
	Vector3 move = Vector3.zero;

	// Use this for initialization
	void Awake () {
		nanoByte = new NanoByte();
		/*displayStats = GameObject.FindGameObjectWithTag("Display").GetComponentsInChildren<Text>();
		
		if(displayStats.Length == 7)
		{

			displayStats[0].GetComponent<Text>().text = nanoByte.getHealth().ToString();
			displayStats[1].GetComponent<Text>().text = nanoByte.getSpeed().ToString();
			displayStats[2].GetComponent<Text>().text = nanoByte.attackValues.getStandardAttack().ToString();
			displayStats[3].GetComponent<Text>().text = nanoByte.attackValues.getSpecial1Attack().ToString();
			displayStats[4].GetComponent<Text>().text = nanoByte.attackValues.getSpecial2Attack().ToString();
			displayStats[5].GetComponent<Text>().text = nanoByte.attackValues.getSpecial3Attack().ToString();
			displayStats[6].GetComponent<Text>().text = nanoByte.attackValues.getSpecial4Attack().ToString();

		}*/

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
				spawnNanoBit();
				counter = 0.0f;

			}
		}

	}

	public void spawnNanoBit()
	{
		GameObject nanoBitInst = Instantiate(Resources.Load("NanoBit") as GameObject);
		nanoBitInst.transform.position = nanoByte.getLocation();
		nanoBitInst.name = nanoBitInst.name + nanoBitNumber;
		holderForBits.Add(nanoBitInst);
		nanoBits.Add(nanoBitInst.GetComponent<NanoBitIns>().nanobit);
		Debug.Log("Created " + nanoBitInst.name);
		++nanoBitNumber;
		damagePlayer(15);
	}

	public void clickedALevelChanger(Button button)
	{

		//this.setAttackBasedOnString(button.name.Split('-')[1], int.Parse(button.name.Split('-')[0]));
	}

	/*public void setAttackBasedOnString(string buttonName, int index)
	{
		
		switch(buttonName)
		{
		case "LvlUStdAtt":
			nanoByte.attackValues.setStandardAttack(nanoByte.attackValues.getStandardAttack() + 1);
			displayStats[index].text = nanoByte.attackValues.getStandardAttack().ToString();
			break;
		case "LvlDStdAtt":
			if(nanoByte.attackValues.getStandardAttack() > 0)
				nanoByte.attackValues.setStandardAttack(nanoByte.attackValues.getStandardAttack() - 1);
			displayStats[index].text = nanoByte.attackValues.getStandardAttack().ToString();
			break;
		case "LvlUSp1":
			nanoByte.attackValues.setSpecial1Attack(nanoByte.attackValues.getSpecial1Attack() + 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlDSp1":
			if(nanoByte.attackValues.getSpecial1Attack() > 0)
				nanoByte.attackValues.setSpecial1Attack(nanoByte.attackValues.getSpecial1Attack() - 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial1Attack().ToString();
			break;
		case "LvlUSp2":
			nanoByte.attackValues.setSpecial2Attack(nanoByte.attackValues.getSpecial2Attack() + 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlDSp2":
			if(nanoByte.attackValues.getSpecial2Attack() > 0)
				nanoByte.attackValues.setSpecial2Attack(nanoByte.attackValues.getSpecial2Attack() - 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial2Attack().ToString();
			break;
		case "LvlUSp3":
			nanoByte.attackValues.setSpecial3Attack(nanoByte.attackValues.getSpecial3Attack() + 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlDSp3":
			if(nanoByte.attackValues.getSpecial3Attack() > 0)
				nanoByte.attackValues.setSpecial3Attack(nanoByte.attackValues.getSpecial3Attack() - 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial3Attack().ToString();
			break;
		case "LvlUSp4":
			nanoByte.attackValues.setSpecial4Attack(nanoByte.attackValues.getSpecial4Attack() + 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial4Attack().ToString();
			break;
		case "LvlDSp4":
			if(nanoByte.attackValues.getSpecial4Attack() > 0)
				nanoByte.attackValues.setSpecial4Attack(nanoByte.attackValues.getSpecial4Attack() - 1);
			displayStats[index].text = nanoByte.attackValues.getSpecial4Attack().ToString();
			break;
		case "LvlDHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() - 1);
			displayStats[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlUHealth":
			if(nanoByte.getHealth() > 0)
				nanoByte.setHealth(nanoByte.getHealth() + 1);
			displayStats[index].text = nanoByte.getHealth().ToString();
			break;
		case "LvlDSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() - 1.0f);
			displayStats[index].text = nanoByte.getSpeed().ToString();
			break;
		case "LvlUSpeed":
			if(nanoByte.getSpeed() > 0)
				nanoByte.setSpeed(nanoByte.getSpeed() + 1.0f);
			displayStats[index].text = nanoByte.getSpeed().ToString();
			break;
		default:
			Debug.Log("Error!!");
			break;
			
		}
		
	}*/
	
	public void damagePlayer(int damage)
	{
		nanoByte.inflictDamage(damage);
		nanoByte.updateHealth(healthBar);
	}
	
}
