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
				var pos = gameObject.transform.position;
				pos.z = 0.0f;
				gameObject.transform.position = pos;
		}
	
		private void pressedHandler (object sender, EventArgs e)
		{
				if (stance == 1)
						return;
				var obj = Instantiate (gameObject) as GameObject;
				obj.name = (gameObject.name);
				var pos = obj.transform.position;
				pos.z = -3.0f;
				gameObject.transform.position = pos;
				//gameObject.name = "placed" + gameObject.name;
				stance++;
		}

}
