using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RobotControl : MonoBehaviour {
	public Transform[] destination;
	public GameObject player;
	public Transform robotHead;

	RaycastHit rayHit;
	enum VaryingDistances { ignoring, looking, following }
	bool isStationary = true;
	NavMeshAgent robotAgent;
	VaryingDistances varyingDistance;

	// Use this for initialization
	void Start () {
		robotAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(DetectPlayer());
		FindTarget();
		RobotReaction();
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

		if (HUDSpawner.isPaused)
		{
			robotAgent.speed = 0;
			robotAgent.angularSpeed = 0;
		}
		else {
			robotAgent.speed = 1;
			robotAgent.angularSpeed = 240;
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

	void FindTarget()
	{
		Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.forward * 5, Color.green, 1);
		if (Physics.Raycast(robotHead.position, transform.forward, out rayHit, 7f))
		{
			if (rayHit.collider.gameObject == player)
			{
				Debug.Log("I have seen the player");
			}
		}
	}

	IEnumerator DetectPlayer()
	{
		float distanceToPlayer;
		distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		if (distanceToPlayer > 6)
		{
			varyingDistance = VaryingDistances.ignoring;
		}
		else if (distanceToPlayer < 6 && distanceToPlayer > 3)
		{
			varyingDistance = VaryingDistances.looking;
		}
		else if (distanceToPlayer < 3)
		{
			varyingDistance = VaryingDistances.following;
			Debug.Log(varyingDistance.ToString());
		}

		yield return new WaitForSeconds(0.2f);
	}

	void RobotReaction()
	{
		Vector3 target;
		target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
		switch (varyingDistance)
		{
			case VaryingDistances.looking:
				float angle;
				angle = AngleCalculation(target);
				if (angle < 60)
				{
					transform.LookAt(target);
				}
				break;
			case VaryingDistances.following:

				transform.LookAt(target);
				break;
		}
	}

	float AngleCalculation(Vector3 target)
	{
		Vector3 displacement;
		float angle;
		displacement = target - transform.position;
		angle = Vector3.Angle(transform.forward, displacement);
		return angle;
	}
}
