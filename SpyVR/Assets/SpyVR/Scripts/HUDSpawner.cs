using UnityEngine;
using System.Collections;

public class HUDSpawner : MonoBehaviour {

	[Tooltip("The maximum allowable delay between two clicks")]
	[Range(0, 1f)]
	public static float doubleClickDelay = 0.2f;

	[HideInInspector]
	public static bool oneClick;

	public GameObject HUD;


	float initTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		SpawnHUD();
	}

	bool DoubleClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (!oneClick)
			{
				oneClick = true;
				initTime = Time.time;
			}
			else {
				oneClick = false;
				return true;
			}
		}
		if (oneClick)
		{
			if ((Time.time - initTime) > doubleClickDelay)
			{
				oneClick = false;
			}
		}
		return false;
	}

	void SpawnHUD()
	{
		if (DoubleClick())
		{
			HUD.SetActive(true);
		}
	}
}
