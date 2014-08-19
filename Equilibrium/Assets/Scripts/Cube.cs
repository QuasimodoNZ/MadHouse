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

		private void releasedHandler (object sender, EventArgs e)
		{
				if (state == BuildingState.Dragging) {
						Vector3 pos = blueprint.transform.position;
						Destroy (blueprint);
			
						if (blueprint.isColliding ()) {
								Destroy (gameObject);
								return;
						}


						Destroy (GetComponent<PanGesture> ());
						pos.x = Blueprint.RoundOff (pos.x);
						pos.y = Blueprint.RoundOff (pos.y);
						pos.z = 0.0f;
						gameObject.transform.position = pos;

						state = BuildingState.Built;
				}
		}
	
		private void pressedHandler (object sender, EventArgs e)
		{
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

						GameObject newBlueprint = (GameObject)GameObject.Instantiate (blueprintPrefab);
						blueprint = newBlueprint.GetComponent<Blueprint> ();
						blueprint.setParent (this.gameObject);
				}
		}
}
