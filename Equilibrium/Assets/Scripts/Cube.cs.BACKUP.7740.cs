using UnityEngine;
using System;
using TouchScript.Gestures;

public class Cube : MonoBehaviour
{
	public enum BuildingState {
		Menu,
		Pallet,
		Dragging,
		Built,
		Selected
	}
	public BuildingState state = BuildingState.Pallet;

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

<<<<<<< HEAD
	private void releasedHandler (object sender, EventArgs e)
	{
		if (state == BuildingState.Dragging) {
			var pos = gameObject.transform.position;
			pos.z = 0.0f;
			gameObject.transform.position = pos;
			state = BuildingState.Built;
=======
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
>>>>>>> feature/locked_to_grid
		}
	}

	private void pressedHandler (object sender, EventArgs e)
	{
		if (state == BuildingState.Built) {
			GameObject.Destroy(gameObject);
			return;
		}
		var obj = Instantiate (gameObject) as GameObject;
		obj.name = (gameObject.name);
		obj.GetComponent<Cube> ().enabled = true;
		obj.GetComponent<TapGesture> ().enabled = true;
		obj.transform.parent = gameObject.transform.parent;
		var pos = obj.transform.position;
		pos.z = -3.0f;
		gameObject.transform.position = pos;
		//gameObject.name = "placed" + gameObject.name;
		state = BuildingState.Dragging;
	}

}
