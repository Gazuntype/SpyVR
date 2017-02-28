using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {

	public GameObject player;

	[HideInInspector]
	public static float timer;

	[HideInInspector]
	public static bool completed;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!HUDSpawner.isPaused)
		{
			timer += 1 * Time.deltaTime;
		}
	}

	public void EndTheGame()
	{
		if (Vector3.Distance(transform.position, player.transform.position) < 4)
		{
			SceneManager.LoadScene("GameOver");
			completed = true;
		}
	}
}
