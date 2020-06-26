using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTarget : MonoBehaviour
{
	[SerializeField] GameObject tracker1;
	[SerializeField] GameObject tracker2;
	[SerializeField] float angle = 0;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float dist = (tracker1.transform.position - tracker2.transform.position).magnitude;
		Quaternion quat = Quaternion.AngleAxis(angle, Vector3.up);
		Vector3 dir = (quat * Vector3.forward).normalized;
		transform.position = tracker1.transform.position + (dir * dist);
	}
}
