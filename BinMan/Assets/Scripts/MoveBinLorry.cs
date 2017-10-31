using UnityEngine;
using System.Collections;

public class MoveBinLorry : MonoBehaviour {

    private Vector3 startposition;
    private Vector3 newposition;
    private float distance = -1f;
	private float nextmove = 5f;
    private bool moving = false;

	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > nextmove) {
            startposition = transform.position;
            newposition =  startposition;
            newposition.x = newposition.x + distance;
            StartCoroutine("MoveIt");
            nextmove += (float)Random.Range(30, 60);
            distance = (float)Random.Range(-1, -3);
        }
	}
	
	IEnumerator MoveIt() {

        float i = 0f; 

        if (!moving)
        {
            moving = true;
            while (i < 1f)
            {
                i += Time.fixedDeltaTime;
                transform.position = Vector3.Lerp(startposition, newposition, i);
                yield return null;
            }
            moving = false;
        }
    }
}
