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

	public void clickedToMoveMenu()
	{
		moveToVisible = !moveToVisible;
		if(moveToVisible)
			changeTo.text = closeLevelUp;
		else
			changeTo.text = openLevelUp;
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
