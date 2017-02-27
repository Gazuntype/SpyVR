using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDSpawner : MonoBehaviour {

	[Tooltip("The maximum allowable delay between two clicks")]
	[Range(0, 1f)]
	public static float doubleClickDelay = 0.2f;

	[HideInInspector]
	public static bool oneClick;

	public GameObject HUD;
	public Material glowMaterial;
	public Image backgroundImage;

	Color glowColor;
	float initTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		glowColor = glowMaterial.GetColor("_EmissionColor");
		glowColor.a = 0.5f;
		backgroundImage.color = glowColor;
		HUD.transform.position = transform.position + new Vector3(0, 0, 1.37f);
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
			if (HUD.activeSelf == false)
			{
				Time.timeScale = 0;
				HUD.SetActive(true);
			}
			else if(HUD.activeSelf == true)
			{
				Time.timeScale = 1;
				HUD.SetActive(false);
			}
		}
	}
}
