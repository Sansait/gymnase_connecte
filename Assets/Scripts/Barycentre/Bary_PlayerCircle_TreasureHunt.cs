using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_PlayerCircle_TreasureHunt : MonoBehaviour
	{
		private Bary_MassPos _massPos;
		private Bary_PlayerPos player;
		[SerializeField]
		private int player_id;
		[SerializeField]
		float mass;

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
			float angle = Vector3.SignedAngle(Vector3.right, player.dir.normalized, Vector3.up);
			angle = angle > 0 ? angle + 15 : angle - 15;
			int steps = (int)(angle / 30);
			Vector3 pos = RotatePointAroundAxis(Vector3.right, steps * 30f, Vector3.up);
			if (this.name == "Circle_Player1")
				Debug.Log(this.name + " " + angle + " " + steps);

			this.transform.position = pos * 17;
			_massPos.AddPosMass(this.transform.position, mass);
		}

		private Vector3 RotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
		{
			Quaternion q = Quaternion.AngleAxis(angle, axis);
			return q * point;
		}
	}
}
