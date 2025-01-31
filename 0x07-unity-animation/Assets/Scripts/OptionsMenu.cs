﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	public Toggle inverted;

	void Start()
	{
		Debug.Log("Here it is: " + this);
		if (PlayerPrefs.GetString("Inverted") != "")
			inverted.isOn = bool.Parse(PlayerPrefs.GetString("Inverted"));

	}
	public void Back()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("PrevScene"));
	}

	public void Apply()
	{
		PlayerPrefs.SetString("Inverted", inverted.isOn.ToString());
		// if (this.GetComponentsInChildren.Toggle.isOn)
		// // if (this.GetComponent<Toggle>().isOn)
		// {
		// 	PlayerPrefs.SetInt("Inverted", 1);
		// }
		// else
		// 	PlayerPrefs.SetInt("Inverted", 0);
	}
}
