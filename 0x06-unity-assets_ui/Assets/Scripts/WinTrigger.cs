using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public GameObject player;
	public Text timerText;

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			player.GetComponent<Timer>().enabled = false;
			timerText.fontSize = 60;
			timerText.color = Color.green;
		}
	}
}
