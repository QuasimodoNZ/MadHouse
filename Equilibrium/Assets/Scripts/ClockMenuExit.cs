using UnityEngine;
using System;
using TouchScript.Gestures;

public class ClockMenuExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable ()
	{
		GetComponent<PressGesture> ().Pressed += pressedHandler;
	}
	
	private void OnDisable ()
	{
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
	}
	
	private void pressedHandler (object sender, EventArgs e){
		Application.Quit(); 
	}
}
