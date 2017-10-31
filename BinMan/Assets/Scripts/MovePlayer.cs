using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float m_speed = 2f;
	public float m_TurnSpeed = 3f;

	private float m_MovementInputValue;
	private float m_TurnInputValue;
	private Rigidbody m_Rigidbody;
    private bool mustmove = false;


	private void Start ()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();

	}


	private void Update ()
	{
        if (Input.anyKey)
        {
            m_MovementInputValue = Input.GetAxis("Vertical");
            m_TurnInputValue = Input.GetAxis("Horizontal");
            mustmove = true;
        }

	
	}

	private void FixedUpdate()
	{
        if (mustmove)
        {
            Move();
            Turn();
            mustmove = false;
        }


	}

	private void Move ()
	{
		// Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
		Vector3 movement = transform.forward * m_MovementInputValue * m_speed * Time.deltaTime;

		// Apply this movement to the rigidbody's position.
		m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
	}


	private void Turn ()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		// Make this into a rotation in the y axis.
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		// Apply this rotation to the rigidbody's rotation.
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}
}

