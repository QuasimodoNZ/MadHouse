﻿/*
Equilibirium, a game simulator for balancing economic progress and environmental collapse.
Copyright (C) 2014, Mad House Studios.
		
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
		
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
			
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;
using System;
using TouchScript.Gestures;

/*
 * used for restarting the game after it has finished.
 */ 
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
