using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimator : MonoBehaviour {

	[Tooltip("Total time of the animation.")]
	public float animationTime;

	[Range(0,10)]
	[Tooltip("The amount of time to delay before beginning the animation.")]
	public float initialDelay = 5;

	[Tooltip("The UI Text component that shall display the animation.")]
	public Text textComponent;

	[TextArea]
	[Tooltip("The string that should be animated")]
	public string text;

	//bool delayComplete;
	// Use this for initialization

	void Start () {
		//delayComplete = false;
		StartCoroutine(AnimateText());
	}
	
	// Update is called once per frame
	void Update () {
		/*if (initialDelay > 0 && !delayComplete)
		{
			initialDelay -= Time.deltaTime;
		}
		else {
			StartCoroutine(AnimateText());
			delayComplete = true;
		}*/
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
