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
			this.transform.position = Vector3.Normalize(player.dir) * 20;
			float mass = player.dir.magnitude / this.transform.position.magnitude;
			_massPos.AddPosMass(this.transform.position, mass);
		}
	}
}
