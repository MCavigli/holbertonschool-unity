using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public GameObject player;
	public GameObject winCanvas;
	public GameObject timerCanvas;
	public Text timerText;
	public Text finalTimeText;
	public AudioSource bgm;
	public AudioSource winSting;


	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			player.GetComponent<Timer>().enabled = false;
			// timerText.fontSize = 60;
			// timerText.color = Color.green;
			Win();
		}
	}
	public void Win()
	{
		bgm.enabled = false;
		winSting.enabled = true;
		winCanvas.SetActive(true);
		finalTimeText.text = timerText.text;
		timerCanvas.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
	}
}
