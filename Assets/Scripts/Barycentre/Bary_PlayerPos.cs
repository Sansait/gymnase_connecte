﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_PlayerPos : MonoBehaviour
	{
		public Vector3 dir;
		public float mass;

		// Update is called once per frame
		void Update()
		{
			dir = this.transform.position;
			mass = dir.magnitude;
		}
	}
}
