using UnityEngine;
using System;
using TouchScript.Gestures;

public class GameOver : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(string text){
		TextMesh t = GetComponentInChildren<TextMesh> ();
		if (t == null)
						Debug.Log ("problemo");
		t.text = text + "\nTap to restart.";
	}

	private void OnEnable ()
	{
		GetComponent<PressGesture> ().Pressed += pressedHandler;
	}
	
	private void OnDisable ()
	{
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
	}

	private void pressedHandler (object sender, EventArgs e)
	{
		Application.LoadLevel (0);
	}
}
