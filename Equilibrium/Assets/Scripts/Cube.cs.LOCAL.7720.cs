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

	private void releasedHandler (object sender, EventArgs e)
	{
		if (state == BuildingState.Dragging) {
			var pos = gameObject.transform.position;
			pos.z = 0.0f;
			gameObject.transform.position = pos;
			state = BuildingState.Built;
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
