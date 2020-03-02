using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRI.ConnectedGymnasium
{
	public class Initialization : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			StartCoroutine(SceneManager.Instance.LoadAsyncScene("Main Menu"));
		}
	}
}
