using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text TimerText;
	float intTime;
	float mSeconds;
	int seconds;
	int minutes;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		UpdateTimer();
	}

	void UpdateTimer()
	{
		intTime += Time.deltaTime;
		minutes = (int)intTime / 60;
		seconds = (int)intTime % 60;
		mSeconds = Time.deltaTime * 1000;
		// mSeconds %= 1000;
		TimerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, mSeconds);
	}
}
