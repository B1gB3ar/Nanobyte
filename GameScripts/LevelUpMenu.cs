using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour {

	public GameObject levelUpMenu;
	public RectTransform moveTo;
	public RectTransform moveBack;
	public bool moveToVisible;
	public Text changeTo;
	public string openLevelUp = "Open Level Up Menu";
	public string closeLevelUp = "Close Level Up Menu";
	public Color upgradedColor;
	
	public Button[,] tierArray;
	public GameObject[] levelUpContainers = new GameObject[8];
	public NanoByteIns nanoByte;
	public GameObject attackRadius;
	public Slider healthBar;
	public Slider usageBar;

	public void clickedToMoveMenu()
	{
		moveToVisible = !moveToVisible;
		if(moveToVisible)
			changeTo.text = closeLevelUp;
		else
			changeTo.text = openLevelUp;
	}
	public void clickedTier(Button button)
	{
		button.gameObject.GetComponent<Image>().color = upgradedColor;
		if((int.Parse(button.name.Split('-')[0]) + 1) < 5)
		{
			tierArray[int.Parse(button.GetComponentInParent<Transform>().parent.name.Split('-')[0]),
			          int.Parse((button.name.Split('-')[0])) + 1].interactable = true;
		}

		switch(button.name.Split('-')[1])
		{
		case "HealthLevel":
			nanoByte.nanoByte.levelUpHealth(25, healthBar);
			break;
		case "SpeedLevel":
			nanoByte.nanoByte.levelUpSpeed(0.75f);
			break;
		case "StdAttLevel":
			nanoByte.nanoByte.attackValues.levelUpAttack(10);
			break;
		case "AttRadiusLevel":
			attackRadius.GetComponent<CircleCollider2D>().radius = 
				attackRadius.GetComponent<CircleCollider2D>().radius + 1;
			break;
		case "SpecAttOneLevel":
			nanoByte.nanoByte.attackValues.levelUpSpec1Att(10, 5);
			break;
		case "SpecAttTwoLevel":
			nanoByte.nanoByte.attackValues.levelUpSpec2Att(10, 5);
			break;
		case "SpecAttThreeLevel":
			nanoByte.nanoByte.attackValues.levelUpSpec3Att(10, 5);
			break;
		case "SpecAttFourLevel":
			nanoByte.nanoByte.attackValues.levelUpSpec4Att(10, 5);
			break;
		default:
			Debug.Log("No value matched");
			break;

		}

	}

	void Awake()
	{

		// TODO I think this iterates over duplicates, though the output is correct this may be unnecessary
		tierArray = new Button[8, 5];
		for(int i = 0; i < levelUpContainers.Length; ++i)
		{
			foreach(Transform tierGameobject in levelUpContainers[i].GetComponentsInChildren<Transform>())
			{
				for(int j = 0; j < 5; ++j)
				{

					foreach(Button tierButton in tierGameobject.GetComponentsInChildren<Button>())
					{	
						if(tierGameobject.name.Contains(j.ToString()))
						{
							tierArray[i, j] = tierButton;
							break;
						}
					}

				}

			}

		}

	}

	void Start()
	{
		levelUpMenu.transform.position = moveBack.position;
		changeTo.text = openLevelUp;
	}

	// Update is called once per frame
	void Update () {

		if(moveToVisible)
			levelUpMenu.transform.position = Vector3.Lerp(levelUpMenu.transform.position, moveTo.position, 
			                                              Time.deltaTime * 2.5f);
		else
			levelUpMenu.transform.position = Vector3.Lerp(levelUpMenu.transform.position, moveBack.position, 
			                                              Time.deltaTime * 2.5f);
	
	}

}
