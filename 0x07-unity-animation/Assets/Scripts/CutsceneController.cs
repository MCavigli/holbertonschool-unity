using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{

	Animator ani;
	public GameObject mCam;
	public GameObject player;
	public GameObject timer;
	public GameObject csCont;

	void Awake()
	{
		ani = GetComponent<Animator>();
	}
	void Transition()
	{
		mCam.SetActive(true);
		timer.SetActive(true);
		csCont.SetActive(false);
		player.GetComponent<PlayerController>().enabled = true;
	}
}