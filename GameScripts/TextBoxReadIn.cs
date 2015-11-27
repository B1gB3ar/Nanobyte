using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextBoxReadIn : MonoBehaviour {

	public TextAsset readInText;
	public string[] fullTextDividedByScene;
	public string[] sceneLines;
	public int currentScene = 1;
	public int currentLine = 0;
	public Text characterText;
	public Text messageText;
	public int posInString = 0;
	public int loggedScene;
	public string character;
	public string message;
	public bool finishedDisplaying = true;
	public float timeToDisplay = 0.025f;
	public RawImage leftImage;
	public RawImage rightImage;
	public RawImage centerImage;

	public RawImage FredSalm;
	public RawImage CassSalm;
	public SceneChanger sceneChanger;

	public RawImage[] imageArray;

	//public int totalAmountOfScenes = 0;

	void Awake()
	{
		// !!! NOTE: We start at index one instead of zero !!!
		fullTextDividedByScene = readInText.text.Split('@');
		outputText();
		//totalAmountOfScenes = fullTextDividedByScene.Length;	
	}

	/******************************************************************************
	 *	
	 * If our current scene is less than all of our scenes, we'll set up an array
	 * 	that is made up of each line of the current scene's lines.
	 * 
	 * If our current line is our last line, we will go to the next scene and reset
	 *  our current line so that it will be at the beginning.
	 * Else if our index (which is our current line) at our array filled with each 
	 *  line is not blank, we call our coroutine (typeText) and increment our
	 *  current line.
	 * Else we increment our current line and recall our function.
	 * 
	**/ 
	public void outputText()
	{
		if(currentScene < fullTextDividedByScene.Length)
		{
			sceneLines = fullTextDividedByScene[currentScene].Split('\n');
		}

		if(currentLine == sceneLines.Length)
		{
			++currentScene;
			sceneChanger.changeScene(currentScene - 1, imageArray);
			currentLine = 0;
		}
		else if(sceneLines[currentLine] != "")
		{
			posInString = 0;
			StartCoroutine(typeText(currentLine));
			++currentLine;
		}
		else
		{
			++currentLine;
			outputText();
		}
	}

	IEnumerator typeText(int tempCurrLine)
	{
		characterText.text = sceneLines[tempCurrLine].Split(":"[0])[0];
		Debug.Log(characterText.text + "1");
		switch(characterText.text)
		{
		case "Fredrick Salm ":
			Debug.Log("CASE ONE");
			leftImage.texture = FredSalm.texture;
			rightImage.texture = null;
			break;
		case "Cassandra Salm ":
			Debug.Log("CASE TWO");
			leftImage.texture = null;
			rightImage.texture = CassSalm.texture;
			break;
		default:
			Debug.Log("CASE DEF");
			leftImage.texture = null;
			rightImage.texture = null;
			break;
		}
		messageText.text = sceneLines[tempCurrLine].Split(":"[0])[1].Substring(0, posInString);
		//Debug.Log("CURR LINE:   " + tempCurrLine + " " + posInString + " " + messageText.text.Length);
		yield return new WaitForSeconds(timeToDisplay);
		if(posInString != sceneLines[tempCurrLine].Split(":"[0])[1].Length + 1)
		{
			StartCoroutine(typeText(tempCurrLine));
			++posInString;
		}
		else
			finishedDisplaying = true;
	}

	IEnumerator updateChangedScene()
	{
		yield return new WaitForSeconds(1f);
		characterText = GameObject.Find("CharacterText").GetComponent<Text>();
		messageText = GameObject.Find("MessageText").GetComponent<Text>();
		currentLine = 0;
		loggedScene = currentScene;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space) && finishedDisplaying)
		{
			finishedDisplaying = false;
			timeToDisplay = 0.065f;
			StopAllCoroutines();
			this.outputText();
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			timeToDisplay = 0.0f;
		}

		if(currentScene != loggedScene)
		{
			StartCoroutine(updateChangedScene());
		}
	}
}
