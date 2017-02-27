using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HUDControl : MonoBehaviour {
	[Tooltip("The GVRAudioSource playing the background music")]
	public GvrAudioSource sound;

	[Tooltip("The Image component of the sound icon")]
	public Image soundImage;

	[Tooltip("The sprite for sound on")]
	public Sprite soundOn;

	[Tooltip("The sprite for sound off")]
	public Sprite soundOff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SoundSwap()
	{
		if (sound.isPlaying)
		{
			sound.Stop();
			soundImage.sprite = soundOff;
		}
		else {
			sound.Play();
			soundImage.sprite = soundOn;
		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("title");
	}
}
