using UnityEngine;
using System;
using TouchScript.Gestures;

public class Improve : MonoBehaviour {

	private GameObject menu;

	public void setMenu(GameObject menu){
		this.menu = menu;
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
		Debug.Log ("Improving!");
		menu.GetComponent<Popup> ().improve ();
	}
}
