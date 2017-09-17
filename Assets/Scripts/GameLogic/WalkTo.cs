using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkTo : MonoBehaviour {

	public Transform goal;
	public bool isOnFans = false;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		agent.speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
