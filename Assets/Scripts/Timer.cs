using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

	public float timer;
	public Text timerLabel;
	public Text GOLabel;
	public MouseClick mouseClick;

	private AudioSource[] _audioSources;
	private AudioSource _tick;


	// Use this for initialization
	void Start () {
		GOLabel.enabled = false;
		//this._audioSources = gameObject.GetComponents<AudioSource>();
		//this._tick = this._audioSources[0];
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		this.Timers();

	}
	/*void PlayTicking()
	{
		this._tick.Play();
	}*/

	public void Timers()
	{
		this.timerLabel.text = String.Format("{0:0}", timer); 

		if (timer <= 10f)
		{
			this.timerLabel.color = Color.red;
			//InvokeRepeating("PlayTicking", 59.9f, 1.0f);

		}
		if (timer <= 0)
		{
			timerLabel.text = "0:00";
			GOLabel.enabled = true;
			mouseClick.enabled = false;
		}
	}
}
