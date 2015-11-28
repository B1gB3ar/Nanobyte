using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutIn : MonoBehaviour {

	public Image fader;
	public AudioSource audioSource;
	public Color textureBlack;
	public Color textureClear;
	public bool fading;
	public bool fadingIn;
	public TextBoxReadIn textReader;

	public void fadeIn()
	{
		fading = true;
		fadingIn = true;
		fader.color = Color.Lerp (fader.color, textureClear, Time.deltaTime);
		if(audioSource == null)
			audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
		audioSource.volume = Mathf.Lerp (audioSource.volume, 1, Time.deltaTime);
		//Debug.Log(fader.color.a + " ALPHA");
	}

	public void fadeOut()
	{
		fading = true;
		fadingIn = false;
		fader.color = Color.Lerp (fader.color, textureBlack, Time.deltaTime);
		if(audioSource == null)
			audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
		audioSource.volume = Mathf.Lerp (audioSource.volume, 0, Time.deltaTime);
	}

	// Use this for initialization
	void Awake () 
	{
		fader.color = textureBlack;
		fading = true;
		fadingIn = true;
		if(audioSource == null)
			audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
		audioSource.volume = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fading)
		{
			if(fadingIn)
			{
				fadeIn();
				if(fader.color.a <= 0.1)
				{
					fader.color = textureClear;
					fading = false;
					textReader.outputText();
				}
			}
			else
			{
				fadeOut();
				if(fader.color.a >= 0.95)
				{
					fader.color = textureBlack;
					fading = false;
					textReader.outputText();
				}
			}
		}
	}
}
