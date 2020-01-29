using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Mass : MonoBehaviour
	{
		private Vector3 posGlob = Vector3.zero;
		private float totalMass;

		public void AddPosMass(Vector3 pos, float mass)
		{
			posGlob += (pos * mass);
			totalMass += mass;
		}

		void Start()
		{

		}

		void Update()
		{
			if (totalMass > 0)
				this.transform.position = posGlob / totalMass;
			totalMass = 0;
			posGlob = Vector3.zero;
		}
	}
}
