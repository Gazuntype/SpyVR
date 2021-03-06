﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIControl : MonoBehaviour {
	public GameObject canvas;
	public Material glowMaterial;
	public Image backgroundImage;
	public Text body;
	public Text header;
	public Text footer;
	public Image image;

	[HideInInspector]
	public static bool introComplete;

	Color glowColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		glowColor = glowMaterial.GetColor("_EmissionColor");
		glowColor.a = 0.5f;
		backgroundImage.color = glowColor;
		if (TextAnimator.animationComplete && Input.GetMouseButtonDown(0))
		{
			SwitchToInstructins();
		}

		if (RaycastMovement.moveBegin && canvas.activeSelf == true)
		{
			canvas.SetActive(false);
		}
	}

	public void SwitchToInstructins()
	{
		body.gameObject.SetActive(false);
		header.gameObject.SetActive(true);
		footer.gameObject.SetActive(true);
		image.gameObject.SetActive(true);
		introComplete = true;
	}
}