using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	public Toggle inverted;
	public AudioMixer BGM;
	public AudioMixer SFX;

	void Start()
	{
		// Debug.Log("Here it is: " + this);
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
	public void SetMusicLvl(float BGMSlider)
	{
		BGM.SetFloat("BGM", BGMSlider);
	}
	public void SetSFXLvl(float SFXSlider)
	{
		SFX.SetFloat("SFX", SFXSlider);
	}
}
