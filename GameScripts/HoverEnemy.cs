using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverEnemy : MonoBehaviour {
	
	bool hovering;
	public SpriteRenderer enemyToChange;
	public Color initialColor;
	public Color changeToColor;

	void Awake()
	{
		enemyToChange = GetComponent<SpriteRenderer>();
		initialColor = enemyToChange.color;
	}

	public void enterHoveringOverEnemy()
	{
		hovering = true;
	}
	public void exitHoveringOverEnemy()
	{
		hovering = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hovering)
			enemyToChange.color = Color.Lerp(enemyToChange.color, changeToColor, Time.deltaTime * 1.5f);
		else
			enemyToChange.color = Color.Lerp(enemyToChange.color, initialColor, Time.deltaTime * 2);
	}
}
