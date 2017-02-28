using UnityEngine;
using System.Collections;

public class mainUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HUDSpawner.isPaused = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			HUDSpawner.isPaused = false;
			gameObject.SetActive(false);
		}
	}
}
