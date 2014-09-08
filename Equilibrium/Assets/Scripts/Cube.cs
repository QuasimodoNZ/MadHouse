using UnityEngine;
using System;
using TouchScript.Gestures;

public class Cube : MonoBehaviour
{
	public GameObject blueprintPrefab;
	private Blueprint blueprint = null;

		public enum BuildingState
		{
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

		private  int RoundOff (float i)
		{
				return ((int)Math.Round (i / 1.0)) * 1;
		}

	private void releasedHandler (object sender, EventArgs e)
	{
		if (state == BuildingState.Dragging) {
			Vector3 pos = blueprint.transform.position;

			if (blueprint.isColliding()){
				Destroy (gameObject);
				Destroy (blueprint.gameObject);
				return;
			}
			Destroy (blueprint.gameObject);
			GetComponent<PanGesture>().enabled = false;
			pos.x = RoundOff (pos.x);
			pos.y = RoundOff (pos.y);
			pos.z = 0.0f;
			gameObject.transform.position = pos;

			state = BuildingState.Built;
			gameObject.tag = Tags.Built;
		}
	}
	
		private void pressedHandler (object sender, EventArgs e)
		{
			var controller = GameObject.FindGameObjectWithTag (Tags.GameController);
			var clock = controller.GetComponent<Clock> ();
			if (clock == null) {
			Debug.LogError ("Oh shit no clock!");
		} else {
			if (clock.getMaterial() < 1){
				gameObject.GetComponent<PanGesture>().enabled = false;
				return;
			} else {
				gameObject.GetComponent<PanGesture>().enabled = true;
				clock.spendMaterial(1);
			}
		}
		if (state == BuildingState.Built) {
			GameObject.Destroy (gameObject);
			return;
		}
		if (state == BuildingState.Pallet) {
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
			tag = Tags.Placing;

			GameObject newBlueprint = (GameObject)GameObject.Instantiate (blueprintPrefab);
			blueprint = newBlueprint.GetComponent<Blueprint> ();
			blueprint.setParent (this.gameObject);
		}
	}
}
