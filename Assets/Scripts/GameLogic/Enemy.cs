using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour{
	protected int Lives;
	protected int Power;
	protected int Speed;
	public bool isDead{ get; set; }
	public Transform goal;
	public bool isOnFans = false;
	private Animator anim;


	void Awake () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isOnFance", isOnFans);
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		agent.speed = 1f;
		isDead = false;
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
			anim.SetBool ("isDead", isDead);
			StopMovement ();
		}
	}

	void OnTriggerEnter(Collider col){
		//need to check if this is the fans or the arrow
		if (col.transform.name == "fance") {
			isOnFans = true;
			StopMovement ();
			anim.SetBool ("isOnFance", isOnFans);
			} else if (col.transform.name == "Bullet") {
			Destroy(col.gameObject);
			hitted ();
		}
	}
	

	private void Dead(){
		GetComponent<CapsuleCollider> ().enabled = false;
		Destroy (gameObject, 6);
	}
}
