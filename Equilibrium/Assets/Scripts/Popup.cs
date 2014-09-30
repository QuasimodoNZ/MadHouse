﻿using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	private GameObject target;
	private BuildingCosts buildings = new BuildingCosts();

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Improve> ().setMenu (gameObject);
		GetComponentInChildren<Remove> ().setMenu (gameObject);
	}

	public void setTarget (GameObject target){
		this.target = target;
	}

	public void improve (){
		Debug.Log ("Improvement!");
		target.name = target.name + "+";
	}

	public void remove(){
		var controller = GameObject.FindGameObjectWithTag (Tags.GameController);
		var clock = controller.GetComponent<Clock> ();
		switch (target.name) {
		case "City":
			clock.spendMaterial(-(buildings.City/2));
			break;
		case "Factory":
			clock.spendMaterial(-(buildings.Factory/2));
			break;
		case "Farm":
			clock.spendMaterial(-(buildings.Farm/2));
			break;
		case "Fishing":
			clock.spendMaterial(-(buildings.Fishing/2));
			break;
		case "Lumber":
			clock.spendMaterial(-(buildings.Lumber/2));
			break;
		case "Mine":
			clock.spendMaterial(-(buildings.Mine/2));
			break;
		case "Power":
			clock.spendMaterial(-(buildings.Power/2));
			break;
		case "School":
			clock.spendMaterial(-(buildings.School/2));
			break;
		}
		Destroy (target);
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
