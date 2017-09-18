using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour{
	protected int Lives;
	protected int Power;
	protected int Speed;
	public bool isDead{ get; set; }
	/*[SerializeField] private*/public Transform goal;
	public bool isOnFans = false;


	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		agent.speed = 1f;
	}

	protected void UpdateSpeed(){
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.speed = this.Speed;
	}
		
	protected void StopMovement(){
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = gameObject.transform.position;
	}
	/// <summary>
	/// when the enemy got shot
	/// </summary>
	protected void hitted(){
		Lives--;
		if (Lives == 0) {
			isDead = true;
		}
	}

	void OnTriggerEnter(Collider col){
		//need to check if this is the fans or the arrow
	}
}
