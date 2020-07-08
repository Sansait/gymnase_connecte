using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CRI.ConnectedGymnasium;

namespace CRI.ConnectedGymnasium.Pong
{
	public class PongManager : MonoBehaviour
	{
		private static PongManager _instance;
		public static PongManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Pong Manager is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		public bool gameStart { get; private set; } = false;
		public int nbPlayerBlue = 0;
		public int nbPlayerRed = 0;
		private float _time = 0;

		[SerializeField] private GameObject ball;
		[SerializeField] private GameObject uiWaiting; // Waiting for players text
		[SerializeField] private GameObject uiGameStarting; // Game starting text

		// Update is called once per frame
		void Update()
		{
			if (gameStart == false && nbPlayerBlue + nbPlayerRed == PlayerManager.Instance.nbPlayer)
			{
				if (uiWaiting.activeSelf == true)
				{
					uiWaiting.SetActive(false);
					uiGameStarting.SetActive(true);
				}
				_time += Time.deltaTime;
				if (_time >= 3f)
				{
					gameStart = true;
					uiGameStarting.SetActive(false);
				//	ball.GetComponent<BallMovement>().enabled = true;
				}
			}
		}
	}
}

