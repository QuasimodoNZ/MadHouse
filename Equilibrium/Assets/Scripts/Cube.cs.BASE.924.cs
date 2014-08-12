using UnityEngine;
using System;
using TouchScript.Gestures;

public class Cube : MonoBehaviour
{
		public int stance = 0;

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
				Destroy (GetComponent<PanGesture> ());
		}
	
		private void pressedHandler (object sender, EventArgs e)
		{
				if (stance == 1)
						return;
				var obj = Instantiate (gameObject) as GameObject;
				obj.name = (gameObject.name);
				//gameObject.name = "placed" + gameObject.name;
				stance++;
		}

}
