using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class PlayerManager : MonoBehaviour
	{
		private static PlayerManager _instance;
		public static PlayerManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Player Manager is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}


		public bool _checkTrackers = true;
		private GameObject[] _trackers;
		public GameObject[] _players { get; private set; }
		public int nbPlayer { get; private set; } = 0;

		// Getting a list of all trackers and a list of all players
		void Start()
		{
			_trackers = GameObject.FindGameObjectsWithTag("Tracker");
			_players = GameObject.FindGameObjectsWithTag("Player");
			Debug.Log("First link player : " + _players[0].name);
			Init_Players();
		}

		void SortArray(GameObject[]  _playerstmp)
		{
			for(int i = 0; i < _playerstmp.Length; i++)
			{
				for (int j = 0; j < _playerstmp.Length; j++)
				{
					if (_playerstmp[j].name == "Player" + (i + 1))
					{
						_players[i] = _playerstmp[j];
					}
				}
			}
		}

		// Setting every player as inactive
		void Init_Players()
		{
			foreach (var player in _players)
			{
				player.SetActive(false);
			}
		}

		public void Reset_Players()
		{
			foreach (var player in _players)
			{
				if (player.activeSelf == true)
				{
					player.transform.SetParent(this.transform);
					player.transform.localPosition = Vector3.zero;
					nbPlayer--;
					player.SetActive(false);
				}
			}
			foreach (var tracker in _trackers)
			{
				tracker.GetComponent<ActiveTracker>().active = false;
				tracker.GetComponent<ActiveTracker>().ResetLastPos();
			}

		}

		void Update()
		{
			if (_checkTrackers)
				CheckForActiveTrackers();
		}

		// Checking every tracker for activity and linking it to a player if it is active
		void CheckForActiveTrackers()
		{
			foreach (var tracker in _trackers)
			{
				if (tracker.GetComponent<ActiveTracker>().toActivate == true && tracker.GetComponent<ActiveTracker>().active == false)
				{
					foreach (var player in _players)
					{
						if (player.activeSelf == false)
						{
							player.SetActive(true);
							player.transform.SetParent(tracker.transform);
							player.transform.localPosition = Vector3.zero;
							tracker.GetComponent<ActiveTracker>().active = true;
							nbPlayer++;
							Debug.Log(player.name + " is paired with " + tracker.name);
							break;
						}
					}
				}
			}
		}
	}
}