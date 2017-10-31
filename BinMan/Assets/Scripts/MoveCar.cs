using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {

	public float speed = 3.0f;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		//rb.velocity = transform.forward * speed;
	}

	void FixedUpdate () {
		Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movement);
	}
	
	void OnCollisionEnter (Collision other){
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Bin")) {
			speed = 0f;
		}
	}
}
