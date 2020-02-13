using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CRI.HitBoxTemplate.Example;

public class PlayerPos_Pong : MonoBehaviour
{
	Mass_Pong _massPos;
	[SerializeField]
	[Tooltip("Team number")]
	private int _team = 0;

	[SerializeField]
	[Tooltip("Mass of the player")]
	private float mass;

	private void Start()
	{
		if (_team != 0)
			_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
		else
			_massPos = null;
	}

	private void Team_Swap(Collision collision)
	{
		if (collision.gameObject.name == "Blue Team (1)" && _team != 1)
		{
			_team = 1;
			_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
			this.GetComponent<MeshRenderer>().material = GameObject.Find("Mass" + _team).GetComponent<MeshRenderer>().material;

		}
		else if (collision.gameObject.name == "Red Team (2)" && _team != 2)
		{
			_team = 2;
			_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
			this.GetComponent<MeshRenderer>().material = GameObject.Find("Mass" + _team).GetComponent<MeshRenderer>().material;

		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Goal")
			Team_Swap(collision);
	}

	// Update is called once per frame
	void Update()
    {
		if (_massPos)
			_massPos.AddPosMass(this.transform.position, mass);
    }
}
