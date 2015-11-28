using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

	public TextBoxReadIn textReadIn;
	public FadeOutIn fadeInOut;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	public void changeScene(int currScene, RawImage[] imageArr, GameObject textDisplay)
	{
		Application.LoadLevelAsync(currScene);
		//TODO Change this so that each scene that needs an image will switch it on or off
		for(int i = 0; i < imageArr.Length; ++i)
		{
			imageArr[i].enabled = false;
		}
		fadeInOut.fadeIn();
		if(currScene == 2)
		{
			textDisplay.SetActive(false);
		}
		//textReadIn.outputText();
	}
}
