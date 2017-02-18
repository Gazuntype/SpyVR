using UnityEngine;
using System.Collections;

public class ColourChanger : MonoBehaviour {
	public Material edgeGlow;
	Color currentColor;
	Color finalColor;
	float interpolant = 0f;
	// Use this for initialization
	void Start () {
		StartCoroutine(ChangeColour());
	}
	
	// Update is called once per frame
	void Update () {
		edgeGlow.SetColor("_EmissionColor", Color.Lerp(currentColor, finalColor, interpolant));
		interpolant += Time.deltaTime * 0.25f;
	}

	IEnumerator ChangeColour()
	{
		while (true)
		{
			currentColor = edgeGlow.GetColor("_EmissionColor");
			finalColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			interpolant = 0;
			yield return new WaitForSeconds(4);
		}

	}
}
