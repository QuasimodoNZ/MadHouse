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
using System.Collections.Generic;

public class Pallet : MonoBehaviour {

	private ArrayList cubes = new ArrayList();
	public bool horizontal;
	public static float TILE_SCALE = 1;
	public static float PADDING = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCube (GameObject c){
		var localCube = c.GetComponent<Cube>();
		if (localCube == null){
			return;
		} else {
			cubes.Add (c);
			int listlength = cubes.Count;
			c.transform.position = gameObject.transform.position;
			if (horizontal == true){
				for (int i = 0; i < listlength; i++){
					((GameObject)cubes[i]).transform.position = gameObject.transform.position + new Vector3(getPalletLocation (i, listlength), 0, -2);
				}
				gameObject.transform.localScale = new Vector3(getNewLength(listlength), TILE_SCALE + PADDING, 1);
			} else {
				for (int i = 0; i < listlength; i++){
					((GameObject)cubes[i]).transform.position = gameObject.transform.position + new Vector3(0, getPalletLocation (i, listlength), -2);
				}
				gameObject.transform.localScale = new Vector3(TILE_SCALE + PADDING, getNewLength (listlength), 1);
			}
		}
	}

	private float getPalletLocation(int index, int listLength){
		return ((index) - ((listLength - 1) / 2f)) * (TILE_SCALE + PADDING);
	}

	private float getNewLength(int listLength){
		return (TILE_SCALE + PADDING) * listLength;
	}

	public bool killSelf(){
		if (cubes.Count != 0)
						return false;
		Destroy (gameObject);

		var huds = GameObject.FindGameObjectsWithTag (Tags.HUD);
		foreach (GameObject o in huds) {
			if(o.GetComponent<HUD>().isValid == false)
				Destroy(o);
		}
		return true;
	}
}
