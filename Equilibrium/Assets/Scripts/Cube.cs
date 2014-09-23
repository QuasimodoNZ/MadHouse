	using UnityEngine;
	using System;
	using TouchScript.Gestures;

	public class Cube : MonoBehaviour {
	private GameObject origin; // used to return to original position in the bag.

	public GameObject blueprintPrefab;
	private Blueprint blueprint = null;
	public BuildingState state;

	public GameObject menuPrefab;
	private GameObject menu;
		
	public void Start(){
	}

	public enum BuildingState
	{
		Menu,
		Pallet,
		Dragging,
		Built,
		Selected
	}


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

	public void setState(BuildingState newState){
		state = newState;
	}

	private void releasedHandler (object sender, EventArgs e)
	{
		if (state == BuildingState.Menu) {
			float x = gameObject.transform.position.x;
			float y = gameObject.transform.position.y;
			if (x > 12 && y < 6 && y > -6){
				GameObject.Find ("PalletHandler/East").GetComponent<Pallet>().AddCube(gameObject);
			}
			else if (x < -12 && y < 6 && y > -6){
				GameObject.Find ("PalletHandler/West").GetComponent<Pallet>().AddCube(gameObject);
			}
			else if (y > 6 && x < 8 && x > -8){
				GameObject.Find ("PalletHandler/North").GetComponent<Pallet>().AddCube(gameObject);
			}
			else if (y < -6 && x < 8 && x > -8){
				GameObject.Find ("PalletHandler/South").GetComponent<Pallet>().AddCube(gameObject);
			}
			else {
				gameObject.transform.parent = origin.transform.parent;
				gameObject.transform.position = origin.transform.position;
			}
			Destroy (origin);
		}
		if (state == BuildingState.Dragging) {
			Vector3 pos = blueprint.transform.position;

			if (blueprint.isColliding()){
				Debug.Log ("blueprint.iscolliding = true");
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

	private void pressedHandler (object sender, EventArgs e){
	if (state == BuildingState.Menu)	
	{
		origin = Instantiate (gameObject) as GameObject;
		origin.transform.position = gameObject.transform.position;
		origin.transform.localScale = new Vector3(1,1,1);
		origin.transform.parent = gameObject.transform.parent;
		origin.SetActive (false);
		gameObject.transform.parent = null;
	} else {
		var controller = GameObject.FindGameObjectWithTag (Tags.GameController);
		var clock = controller.GetComponent<Clock> ();
		if (clock == null) {
			Debug.LogError ("Oh shit no clock!");
		}
	if (state == BuildingState.Built) {
		if (menu == null){
			GameObject obj = Instantiate (menuPrefab) as GameObject;
			obj.transform.position = gameObject.transform.position;
			obj.name = gameObject.name + "Menu";
			obj.transform.parent = gameObject.transform;
			obj.GetComponent<Popup>().setTarget(gameObject);
			menu = obj;
		} else {
			Destroy (menu);
			menu = null;
		}
	}
	if (state == BuildingState.Pallet) {
		var obj = Instantiate (gameObject) as GameObject;
		obj.name = (gameObject.name);
		obj.GetComponent<Cube> ().enabled = true;
		obj.GetComponent<TapGesture> ().enabled = true;
		obj.transform.parent = gameObject.transform.parent;
		obj.GetComponent<Cube>().setState (BuildingState.Pallet);
		var pos = obj.transform.position;
		pos.z = -3.0f;
		gameObject.transform.position = pos;
		//gameObject.name = "placed" + gameObject.name;
		state = BuildingState.Dragging;
		tag = Tags.Placing;
		
		GameObject newBlueprint = (GameObject)GameObject.Instantiate (blueprintPrefab, gameObject.transform.position, gameObject.transform.rotation);
		blueprint = newBlueprint.GetComponent<Blueprint> ();
		blueprint.setParent (this.gameObject);
		}
	}
}
	public void tick(){
		gameObject.renderer.material.color = Color.white;
	}
}
