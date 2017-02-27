using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DescriptionControl : MonoBehaviour {

	[HideInInspector]
	public static bool animationComplete;

	[Tooltip("Total time of the animation.")]
	public float animationTime;

	[Range(0, 10)]
	[Tooltip("The amount of time to delay before beginning the animation.")]
	public float initialDelay = 5;

	[Tooltip("The UI Text component that shall display the animation.")]
	public Text textComponent;

	string text;

	//bool delayComplete;
	// Use this for initialization

	public void StartText()
	{
		StartCoroutine(AnimateText());
	}

	public void EndText()
	{
		textComponent.text = "";
	}

	void Start()
	{
		text = this.gameObject.name;
	}

	// Update is called once per frame
	void Update()
	{
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
		textComponent.transform.localPosition = new Vector3(transform.localPosition.x, textComponent.transform.localPosition.y, textComponent.transform.localPosition.z);
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
