using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RobotControl : MonoBehaviour {
	public Transform[] destination;

	[HideInInspector]
	public static bool isChosen;

	bool isStationary = true;
	NavMeshAgent robotAgent;
	// Use this for initialization
	void Start () {
		robotAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isStationary)
		{
			Vector3 chosenDestination;
			List<float> closestDestinations;

			closestDestinations = GetClosestDestinations();
			chosenDestination = ChooseDestination(closestDestinations);
			robotAgent.SetDestination(chosenDestination);
			isStationary = false;
		}

		if (robotAgent.remainingDistance <= robotAgent.stoppingDistance)
		{
			isStationary = true;
		}
	}

	List<float> GetClosestDestinations()
	{
		List<float> ClosestDestinations = new List<float>();

		foreach (Transform individualDestination in destination)
		{
			ClosestDestinations.Add(Vector3.Distance(transform.position, individualDestination.position));
		}
		ClosestDestinations.Sort();
		return ClosestDestinations;
	}

	Vector3 ChooseDestination(List<float> destinations)
	{
		float[] distance = new float[4];
		float chosenDistance;
		Vector3 chosenDestination = destination[0].position;
		int randomIndex;

		for (int i = 0; i < 4; i++)
		{
			distance[i] = destinations[i];
		}
		randomIndex = Random.Range(0, 3);
		chosenDistance = distance[randomIndex];
		foreach (Transform individualDestination in destination)
		{
			if ((int)chosenDistance == (int)Vector3.Distance(transform.position, individualDestination.position))
			{
				chosenDestination = individualDestination.position;
			}
		}
		return chosenDestination;
	}
}
