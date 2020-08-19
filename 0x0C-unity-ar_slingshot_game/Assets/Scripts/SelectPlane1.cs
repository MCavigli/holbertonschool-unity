using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SelectPlane1 : MonoBehaviour
{
	public GameObject startButton;
	PlaceTargets scriptPlaceTargets;
	SelectPlane1 scriptSelectPlane1;
	// int flag;

	void Awake()
	{
		scriptPlaceTargets = GetComponent<PlaceTargets>();
		scriptSelectPlane1 = GetComponent<SelectPlane1>();
	}

	void FixedUpdate()
	{
		// if (!GetTouch())
		// 	return;
		// if (flag == 0)
		// 	startGame();
		if (Input.touchCount > 0)
			startGame();
	}

	// bool GetTouch()
	// {
	// 	if (Input.touchCount > 0)
	// 		return true;
	// 	return false;
	// }

	void startGame()
	{
		startButton.SetActive(true);
		// flag = 1;
	}

	public void startGameScript()
	{
		scriptPlaceTargets.enabled = true;
		startButton.SetActive(false);
		scriptSelectPlane1.enabled = false;
	}
}
