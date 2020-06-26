using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRotation : MonoBehaviour
{
	[SerializeField] private GameObject tracker;
	// Update is called once per frame
	void Update()
	{
		Vector3 tmp = Vector3.ProjectOnPlane(tracker.transform.forward, Vector3.up);
		float angle = Vector3.SignedAngle(tmp, Vector3.forward, Vector3.up);
		Debug.Log(angle);
		Vector3 euler = Vector3.zero;
		euler.x = angle;
		transform.eulerAngles = euler;
	}
}
