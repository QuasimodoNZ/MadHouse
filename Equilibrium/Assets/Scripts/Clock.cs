using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;

public class Clock : MonoBehaviour {

	private int count = 0;
	public GUIText text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable ()
	{
		GetComponent<PressGesture> ().Pressed += pressedHandler;
		GetComponent<ReleaseGesture> ().Released += releasedHandler;
	}
	
	private void OnDisable ()
	{
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
	}

	private void releasedHandler (object sender, EventArgs e)
	{
		Debug.LogWarning ("HELP!!!");
		nextTurn ();
		text.text = Convert.ToString (count);
	}

	private void pressedHandler (object sender, EventArgs e)
	{
		Debug.LogWarning("do I work?");
	}

	public int getCount(){
		return count;
	}

	public void nextTurn(){
		count++;
	}
}
