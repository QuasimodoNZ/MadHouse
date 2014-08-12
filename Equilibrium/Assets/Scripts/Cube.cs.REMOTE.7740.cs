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

		private  int RoundOff (float i)
		{
				return ((int)Math.Round (i / 1.0)) * 1;
		}

		private void releasedHandler (object sender, EventArgs e)
		{
				Destroy (GetComponent<PanGesture> ());
			
				Vector3 pos = gameObject.transform.position;
				pos.x = RoundOff (pos.x);
				pos.y = RoundOff (pos.y);

				gameObject.transform.position = pos;
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
