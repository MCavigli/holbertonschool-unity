using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
	public GameObject player;

	void OnTriggerExit(Collider other)
	{
		if (other.name == "Player")
		{
			player.GetComponent<Timer>().enabled = true;
		}
	}
}
