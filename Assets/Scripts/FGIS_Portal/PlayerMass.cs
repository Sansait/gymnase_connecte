using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMass : MonoBehaviour
{
	CenterMass _centerMass;

	[SerializeField]
	[Tooltip("Mass of the player")]
	private float mass;

	[SerializeField] LineRenderer energyLink;

	private void Start()
	{
		_centerMass = GameObject.Find("Mass").GetComponent<CenterMass>();

	}

	// Update is called once per frame
	void Update()
	{
		if (_centerMass)
        {
			_centerMass.AddPosMass(this.transform.position, mass);

			if(energyLink)
            {
				energyLink.gameObject.SetActive(true);
				energyLink.SetPosition(0,_centerMass.transform.position);
				energyLink.SetPosition(1, this.transform.position);
			}
		}

	}
}
