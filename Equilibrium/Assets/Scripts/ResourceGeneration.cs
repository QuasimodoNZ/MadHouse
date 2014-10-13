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
using System;

/*
 * allows for random generation of a map, needs to be further implemented however
 */ 
public class ResourceGeneration : MonoBehaviour {
	
	//public GameObject resource = (GameObject) Resources.Load("Basic Resource");
	private System.Random rand;

	// Use this for initialization
	void Start () {

		rand = new System.Random();
		for (float i = -16; i < 15; i++) {
			for(float j = -9; j < 8; j++){
				if(rand.Next(0, 100) > 90){

					GameObject resource = (GameObject) Resources.Load (generateDiffResources(i, j));
					Vector3 temp = new Vector3(i, j, 1);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
					resource.tag = Tags.Resource;
				}
			}
		}
	}

	
	private string generateDiffResources(double x, double y){
		int num = rand.Next (0, 100);
		if(num < 12)
						return "Coal";
		if (num < 24)
						return "Copper Ore";
		if (num < 36)
						return "Farmland";
		if (num < 48)
						return "Fish";
		if (num < 60)
						return "Gold Ore";
		if (num < 72)
						return "Iron Ore";
		if (num < 84)
						return "Oil";
				else
						return "Trees";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
