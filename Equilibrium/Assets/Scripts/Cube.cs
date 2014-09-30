﻿	using UnityEngine;
	using System;
	using TouchScript.Gestures;

	public class Cube : MonoBehaviour {
	private GameObject origin; // used to return to original position in the bag.

	public GameObject blueprintPrefab;
	private Blueprint blueprint = null;
	public BuildingState state;

	public GameObject menuPrefab;
	private GameObject menu;
	private BuildingCosts buildings;
		
	public void Start(){
	}

	public enum BuildingState
	{
		Menu,
		Picked,
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
				GameObject.Find ("PalletHandler/EastText").GetComponent<HUD>().isValid = true;
				disable ();
			}
			else if (x < -12 && y < 6 && y > -6){
				GameObject.Find ("PalletHandler/West").GetComponent<Pallet>().AddCube(gameObject);
				GameObject.Find ("PalletHandler/WestText").GetComponent<HUD>().isValid = true;
				disable ();
			}
			else if (y > 6 && x < 8 && x > -8){
				GameObject.Find ("PalletHandler/North").GetComponent<Pallet>().AddCube(gameObject);
				GameObject.Find ("PalletHandler/NorthText").GetComponent<HUD>().isValid = true;
				disable ();
			}
			else if (y < -6 && x < 8 && x > -8){
				GameObject.Find ("PalletHandler/South").GetComponent<Pallet>().AddCube(gameObject);
				GameObject.Find ("PalletHandler/SouthText").GetComponent<HUD>().isValid = true;
				disable ();
			}
			else {
				gameObject.transform.parent = origin.transform.parent;
				gameObject.transform.position = origin.transform.position;
			}
			Destroy (origin);
		}
		if (state == BuildingState.Dragging) {
			Vector3 pos = blueprint.transform.position;
			var controller = GameObject.FindGameObjectWithTag (Tags.GameController);
			var clock = controller.GetComponent<Clock> ();
			if (blueprint.isColliding()){
				Debug.Log ("blueprint.iscolliding = true");

				switch(gameObject.name){
				case "City":
					clock.spendMaterial(-(buildings.City));
					break;
				case "Factory":
					clock.spendMaterial(-(buildings.Factory));
					break;
				case "Farm":
					clock.spendMaterial(-(buildings.Farm));
					break;
				case "Fishing":
					clock.spendMaterial(-(buildings.Fishing));
					break;
				case "Lumber":
					clock.spendMaterial(-(buildings.Lumber));
					break;
				case "Mine":
					clock.spendMaterial(-(buildings.Mine));
					break;
				case "Power":
					clock.spendMaterial(-(buildings.Power));
					break;
				case "School":
					clock.spendMaterial(-(buildings.School));
					break;
				}

				Destroy (gameObject);
				Destroy (blueprint.gameObject);
				return;
			}
			else if(clock.getMaterial() < 0){

				switch(gameObject.name){
				case "City":
					clock.spendMaterial(-(buildings.City));
					break;
				case "Factory":
					clock.spendMaterial(-(buildings.Factory));
					break;
				case "Farm":
					clock.spendMaterial(-(buildings.Farm));
					break;
				case "Fishing":
					clock.spendMaterial(-(buildings.Fishing));
					break;
				case "Lumber":
					clock.spendMaterial(-(buildings.Lumber));
					break;
				case "Mine":
					clock.spendMaterial(-(buildings.Mine));
					break;
				case "Power":
					clock.spendMaterial(-(buildings.Power));
					break;
				case "School":
					clock.spendMaterial(-(buildings.School));
					break;
				}
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
		
		switch(obj.name){
				case "City":
					clock.spendMaterial(buildings.City);
					break;
				case "Factory":
					clock.spendMaterial(buildings.Factory);
					break;
				case "Farm":
					clock.spendMaterial(buildings.Farm);
					break;
				case "Fishing":
					clock.spendMaterial(buildings.Fishing);
					break;
				case "Lumber":
					clock.spendMaterial(buildings.Lumber);
					break;
				case "Mine":
					clock.spendMaterial(buildings.Mine);
					break;
				case "Power":
					clock.spendMaterial(buildings.Power);
					break;
				case "School":
					clock.spendMaterial(buildings.School);
					break;
		}

		GameObject newBlueprint = (GameObject)GameObject.Instantiate (blueprintPrefab, gameObject.transform.position, gameObject.transform.rotation);
		blueprint = newBlueprint.GetComponent<Blueprint> ();
		blueprint.setParent (this.gameObject);
		}
	}
}
	public void disable(){
		gameObject.GetComponent<PanGesture>().enabled = false;
		gameObject.GetComponent<PressGesture>().enabled = false;
		gameObject.GetComponent<ReleaseGesture>().enabled = false;
	}

	public void enable(){
		Debug.Log ("Enabling!");
		gameObject.GetComponent<PanGesture>().enabled = true;
		gameObject.GetComponent<PressGesture>().enabled = true;
		gameObject.GetComponent<ReleaseGesture>().enabled = true;
	}
	public void tick(){
		gameObject.renderer.material.color = Color.white;
	}
}
