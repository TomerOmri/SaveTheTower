using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private GameObject gun;
	private GameObject spawnPoint;
	private bool isShooting;
	[SerializeField] private GameObject _bullet;

	void Start () {
		gun = gameObject.transform.GetChild (0).gameObject;
		spawnPoint = gun.transform.GetChild (0).gameObject;
		isShooting = false;
	}

	//Shoot function is IEnumerator so we can delay for seconds
	IEnumerator Shoot() {
		isShooting = true;
		GameObject bullet = Instantiate(_bullet,spawnPoint.transform.position,spawnPoint.transform.rotation);
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		//add force to the bullet in the direction of the spawnPoint's forward vector
		rb.AddForce(spawnPoint.transform.forward * 500f);
		//play the gun shot sound and gun animation
		//GetComponent<AudioSource>().Play ();
		gun.GetComponent<Animation>().Play ();
		//destroy the bullet after 1 second
		Destroy (bullet, 1);
		//wait for 1 second and set isShooting to false so we can shoot again
		yield return new WaitForSeconds (1f);
		isShooting = false;
	}
		
	void Update () {
		if (Input.anyKeyDown) {
			if (!isShooting) {
				StartCoroutine ("Shoot");
			}
		}
	}
}