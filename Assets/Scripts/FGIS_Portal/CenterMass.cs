using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMass : MonoBehaviour
{
	private Vector3 globalPosition = Vector3.zero;
	private float globalMass;

	// Update is called once per frame
	void Update()
	{
		if (globalMass > 0)
        {
			this.transform.position = globalPosition / globalMass;
		}
		globalMass = 0;
		globalPosition = Vector3.zero;
	}

	public void AddPosMass(Vector3 pos, float mass)
	{
		globalPosition += (pos * mass);
		globalMass += mass;
	}

}
