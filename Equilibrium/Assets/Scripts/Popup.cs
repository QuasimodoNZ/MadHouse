/*
Equilibirium, a game simulator for balancing economic progress and environmental collapse.
Copyright (C) 2014, Mad House Studios.
		
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
		
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
			
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;
using System.Collections;

/*
 * building menum has remove and improve buttons
 */ 
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

	/*
	 * destroys building and refunds half of material costs
	 */ 
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
