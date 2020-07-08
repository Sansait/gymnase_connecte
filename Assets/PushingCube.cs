using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingCube : MonoBehaviour
{

	private Vector3 _lastPos;
	private Vector3 _lastMove;

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("1");
		if (collision.gameObject.tag == "Ball")
		{
			Debug.Log("2");
			//collision.gameObject.GetComponent<Rigidbody>().AddForce(_lastMove, ForceMode.Impulse);
		}
	}


	// Update is called once per frame
	void Update()
	{
		_lastMove = this.transform.position - _lastPos;
		_lastPos = this.transform.position;
	}
}
