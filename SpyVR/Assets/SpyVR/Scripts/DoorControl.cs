using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorControl : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToNextScene()
	{
		if (Vector3.Distance(player.transform.position, transform.position) < 2)
		{
			SceneManager.LoadScene("main");
		}
	}
}
