using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CarAI : MonoBehaviour {

	NavMeshAgent agent;
	Transform car;

	public Vector3 dest = new Vector3(65, 250.85f, 510);

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		car = GetComponent<Transform>();

		Invoke("Move", 1f);
	}

	void Move()
	{
		// car.position = new Vector3(car.position.x, car.position.y - 3, car.position.z);
		agent.SetDestination(dest);
	}
	
}
