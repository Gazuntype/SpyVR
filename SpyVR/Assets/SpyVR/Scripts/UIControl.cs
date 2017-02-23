using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	public Material glowMaterial;
	public Image backgroundImage;

	Color glowColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		glowColor = glowMaterial.GetColor("_EmissionColor");
		glowColor.a = 0.5f;
		backgroundImage.color = glowColor;
	}
}