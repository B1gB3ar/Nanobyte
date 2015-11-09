using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour {

	public bool endOfLevel;

	public CanvasGroup levelUpMenu;
	public RectTransform moveTo;
	public RectTransform moveBack;
	public bool moveToVisible;
	public Text changeTo;
	public Color upgradedColor;
	
	public Button[,] tierArray;
	public GameObject[] levelUpContainers = new GameObject[7];
	public NanoByteIns nanoByte;
	public GameObject attackRadius;
	public Slider healthBar;
	public Slider usageBar;

	public SpecialAttackKeys specialAttackKeys;
	
	public void clickedTier(Button button)
	{
		button.gameObject.GetComponent<Image>().color = upgradedColor;
		if((int.Parse(button.name.Split('-')[0]) + 1) < 5)
		{
			tierArray[int.Parse(button.GetComponentInParent<Transform>().parent.name.Split('-')[0]),
			          int.Parse((button.name.Split('-')[0])) + 1].interactable = true;
			tierArray[int.Parse(button.GetComponentInParent<Transform>().parent.name.Split('-')[0]),
			          int.Parse((button.name.Split('-')[0]))].interactable = false;
		}
		else
		{
			tierArray[int.Parse(button.GetComponentInParent<Transform>().parent.name.Split('-')[0]),
			          int.Parse((button.name.Split('-')[0]))].interactable = false;
		}

		//TODO Change these to work with the new special attacks
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
		case "LasersLevel":
			nanoByte.nanoByte.attackValues.levelUp_Lasers(10, 5);
			break;
		case "FlashFreezeLevel":
			nanoByte.nanoByte.attackValues.levelUp_FlashFreeze(10, 5);
			break;
		case "SlowFreezeLevel":
			attackRadius.GetComponent<CircleCollider2D>().radius = 
				attackRadius.GetComponent<CircleCollider2D>().radius + 1;
			break;
		case "StealthLevel":
			nanoByte.nanoByte.attackValues.levelUp_Stealth(10, 5);
			break;
		default:
			Debug.Log("No value matched");
			break;

		}
		specialAttackKeys.updateAttacks();

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
		levelUpMenu.alpha = 0;
		levelUpMenu.interactable = false;
		levelUpMenu.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () {

		if(endOfLevel)
		{
			levelUpMenu.alpha = Mathf.Lerp(levelUpMenu.alpha, 1, Time.deltaTime * 2);
			levelUpMenu.interactable = true;
			levelUpMenu.blocksRaycasts = true;
		}
		else
		{
			levelUpMenu.alpha = Mathf.Lerp(levelUpMenu.alpha, 0, Time.deltaTime * 2);
			levelUpMenu.interactable = false;
			levelUpMenu.blocksRaycasts = false;
		}
	
	}

}
