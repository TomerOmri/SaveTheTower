using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour{
	protected int Lives;
	protected int Power;
	protected int Speed;
	public bool isDead = false;
	public Transform goal;
	public bool isOnFans = false;
	private Animator anim;
	private float HitTime = 0;


	void Awake () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isOnFance", isOnFans);
		anim.SetBool ("isDead", isDead);

		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position;
		agent.speed = 1f;
		isDead = false;
	}

	private void hitFance()
	{
		Debug.Log ("hitFance");
		GameManager.Instance.hitFance (Power);
	}

	void Update(){
		if (isOnFans) {
			//wait for 2 seconds
			if (HitTime > 0) {
				HitTime -= Time.deltaTime;
			} else {//hit fance
				hitFance ();
				HitTime = 2;
			}
		}
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
			Dead ();
		}
	}

	void OnTriggerEnter(Collider col){
		//need to check if this is the fans or the arrow
		if (col.transform.name.Contains("fance")) {
			isOnFans = true;
			StopMovement ();
			anim.SetBool ("isOnFance", isOnFans);
		} else if (col.transform.name.Contains("Bullet")) {
			Debug.Log ("Hitted by a bullet");
			Destroy (col.gameObject);
			hitted ();
		} else {
			//for test if colide something else
			Debug.Log ("Hitted by something else");
		}
	}
	

	private void Dead(){
		GetComponent<CapsuleCollider> ().enabled = false;
		Destroy (gameObject, 6);
	}
}
