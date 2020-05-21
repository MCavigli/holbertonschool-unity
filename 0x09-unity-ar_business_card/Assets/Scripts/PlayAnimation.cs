using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayAnimation : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	// public Animator animationClips;
	public GameObject n;
	public GameObject nds;
	public GameObject t;
	public GameObject tds;
	public GameObject q0;
	public GameObject q1;
	public GameObject q2;
	public GameObject q3;

	void Start()

	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			// Play  when target is found
			// animationClips.enabled = true;
			n.GetComponent<Animator>().enabled = true;
			nds.GetComponent<Animator>().enabled = true;
			t.GetComponent<Animator>().enabled = true;
			tds.GetComponent<Animator>().enabled = true;
			q0.GetComponent<Animator>().enabled = true;
			q1.GetComponent<Animator>().enabled = true;
			q2.GetComponent<Animator>().enabled = true;
			q3.GetComponent<Animator>().enabled = true;
		}

		else
		{
			// Stop  when target is lost
			// animationClips.enabled = false;
			n.GetComponent<Animator>().enabled = false;
			nds.GetComponent<Animator>().enabled = false;
			t.GetComponent<Animator>().enabled = false;
			tds.GetComponent<Animator>().enabled = false;
			q0.GetComponent<Animator>().enabled = false;
			q1.GetComponent<Animator>().enabled = false;
			q2.GetComponent<Animator>().enabled = false;
			q3.GetComponent<Animator>().enabled = false;
		}
	}
}
