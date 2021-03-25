using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMass : MonoBehaviour
{
	CenterMass _centerMass;

	[SerializeField]
	[Tooltip("Mass of the player")]
	private float mass;

	private void Start()
	{
		_centerMass = GameObject.Find("Mass").GetComponent<CenterMass>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_centerMass)
			_centerMass.AddPosMass(this.transform.position, mass);
	}
}
