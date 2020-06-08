using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_PlayerCircle : MonoBehaviour
	{
		private Bary_MassPos _massPos;
		private Bary_PlayerPos player;
		[SerializeField]
		private int player_id;

		// Start is called before the first frame update
		void Awake()
		{
			_massPos = GameObject.Find("Mass").GetComponent<Bary_MassPos>();
			try
			{
				player = GameObject.Find("Player" + player_id.ToString()).GetComponent<Bary_PlayerPos>();
			}
			catch (NullReferenceException e)
			{
				this.gameObject.SetActive(false);
			}
		}

		// Update is called once per frame
		void Update()
		{
			float mag = player.dir.magnitude;
			float mass = 1;
			if (mag < 17.5f)
			{
				this.transform.position = Vector3.Normalize(player.dir) * 18.8f;
				mass = 1;
			}
			if (mag >= 17.5f)
			{
				this.transform.position = Vector3.Normalize(player.dir) * 21;
				mass = 2;
			}
			if (mag >= 24.5f)
			{
				this.transform.position = Vector3.Normalize(player.dir) * 23.5f;
				mass = 3;
			}
			_massPos.AddPosMass(this.transform.position, mass);
		}
	}
}
