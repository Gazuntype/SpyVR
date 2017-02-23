using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimator : MonoBehaviour {
	[Tooltip("Write the text that should be animated.")]
	public string text;

	[Tooltip("Total time of the animation.")]
	public float animationTime;

	public Text textComponent;

	// Use this for initialization

	void Start () {
		StartCoroutine(AnimateText());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AnimateText()
	{
		for (int i = 0; i < text.Length; i++)
		{
			if (i == 0)
			{
				textComponent.text = text[i].ToString();
			}
			else {
				textComponent.text += text[i];
			}
			yield return new WaitForSeconds(animationTime / text.Length);
		}
	}
}
