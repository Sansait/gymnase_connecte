using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace CRI.ConnectedGymnasium
{
	public class Search_Active_Tracker : MonoBehaviour
	{
		private PlayerManager playerManager;
		void OnEnable()
		{
			SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
			playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
		}

		// A SteamVR device got connected/disconnected
		private void OnDeviceConnected(int index, bool connected)
		{

			if (connected)
			{
				if (OpenVR.System != null)
				{
					//lets figure what type of device got connected
					ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)index);
					if (deviceClass == ETrackedDeviceClass.Controller)
					{
						// not using any controllers at the moment
						Debug.Log("Controller got connected at index:" + index);
					}
					else if (deviceClass == ETrackedDeviceClass.GenericTracker)
					{
						Debug.Log("Tracker got connected at index:" + index);
						// index 0 is the HMD
						if (index > 0)
							playerManager._trackers[index - 1].GetComponent<ActiveTracker>().toActivate = true;
					}
				}
			}
		}
	}
}