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

	private int _newTeam;
	[SerializeField]
	[Tooltip("Mass of the player")]
	private float mass;

	private void Start()
	{
		_newTeam = _team;
		if (_team != 0)
			_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
	}

	// Update is called once per frame
	void Update()
    {
		if ((this.transform.position.x > 18 || this.transform.position.x < -18) && _team == 0)
			_newTeam = this.transform.position.x > 18 ? 1 : 2;
		if (_newTeam != _team && _newTeam != 0)
		{
			_team = _newTeam;
			_massPos = GameObject.Find("Mass" + _team).GetComponent<Mass_Pong>();
			this.GetComponent<MeshRenderer>().material = GameObject.Find("Mass" + _team).GetComponent<MeshRenderer>().material;
		}
		else if (_newTeam != _team && _newTeam == 0)
			_massPos = null;
		if (_massPos)
			_massPos.AddPosMass(this.transform.position, mass);
    }
}
