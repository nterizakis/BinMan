using UnityEngine;
using System.Collections;

public class PickBin : MonoBehaviour 
{
	private bool isPushing = false;

	private Rigidbody rb;
	public GameObject binman;

	private void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	private void Update()
	{
		// press fire to drop item, if carrying something
		if (Input.GetKeyDown("space"))
		{
			if (isPushing)
			{
				isPushing = false;
				transform.parent = null;
				rb.isKinematic = false;
			}
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player") && !isPushing)
		{
			binman = other.gameObject;
			transform.parent = binman.transform;
			rb.isKinematic = true;
			isPushing = true;
		}
	}
}
