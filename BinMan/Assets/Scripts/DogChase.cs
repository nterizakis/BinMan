using UnityEngine;
using System.Collections;

public class DogChase : MonoBehaviour {

    public float speed;
    public Transform dogTransform;
    public float reach;
    public Transform originalDogTransform;
    private bool moving = false;
    private float distance;

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Garden"))
        {
            dogTransform.LookAt(originalDogTransform);
            StartCoroutine(Move("back"));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Garden"))
        {
            dogTransform.LookAt(transform);
            StartCoroutine(Move("toward"));
        }
    }

    private void OnCollisionStay(Collision other)
    {
		if (other.gameObject.CompareTag("Garden"))
        {
            dogTransform.LookAt(transform);
			StartCoroutine(Move("toward"));
        }
    }

    IEnumerator Move(string movement)
    {
//		if (!moving) {
			moving = true;
            if (movement == "toward")
            {
                distance = Mathf.Abs(Vector3.Distance(transform.position, dogTransform.position));
                while (distance > reach)
                {
                    dogTransform.position += dogTransform.forward * speed * Time.deltaTime;
                    distance = Mathf.Abs(Vector3.Distance(transform.position, dogTransform.position));
                    yield return null;
                }
            }
            else if (movement == "back")
            {
                distance = Mathf.Abs(Vector3.Distance(originalDogTransform.position, dogTransform.position));
                while (distance > reach)
                {
                    dogTransform.position += dogTransform.forward * 3 * speed * Time.deltaTime;
                    distance = Mathf.Abs(Vector3.Distance(originalDogTransform.position, dogTransform.position));
                    yield return null;
                }
                dogTransform.rotation = originalDogTransform.rotation;
            }
            moving = false;
  //      }
    }
}
