using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (EndGame.completed)
		{
			Text text = GetComponent<Text>();
			text.text = "It took you " + (int)EndGame.timer + " seconds";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
