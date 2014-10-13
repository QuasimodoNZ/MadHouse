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
 * used for starting the game.
 */ 
public class MenuBag : MonoBehaviour {
	public GameObject world;
	private int bagCount;

	// Use this for initialization
	void Start () {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.Draggable)){
			Cube component = obj.GetComponent<Cube>();
			if(component!=null){
				component.setState(Cube.BuildingState.Menu);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		bagCount = 0;
		foreach (Transform child in transform) {
			bagCount++;
		}
		if (bagCount == 2) {
			//THIS IS WHERE THE GAME STARTS
			//Destroy empty pallets
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.Pallet)){
				Pallet component = obj.GetComponent<Pallet>();
				if(component!=null)
					component.killSelf();
			}
			//Set building states to be buildable
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag(Tags.Draggable)){
				Cube component = obj.GetComponent<Cube>();
				if(component!=null){
					component.setState(Cube.BuildingState.Pallet);
					component.enable ();
				}
			}
			//Build terrain object
			GameObject start;
			start = (GameObject) GameObject.Instantiate (world);
			start.name = "Terrain";
			Destroy (gameObject);
		}
	}
}
