using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Bary_Target : MonoBehaviour
	{

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Mass")
			{
				Bary_Manager.Instance.score++;
				this.gameObject.SetActive(false);
				Bary_TargetManager.Instance.nbTargetDown++;
			}
		}
	}
}
