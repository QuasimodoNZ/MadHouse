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
 * displays scores underneath each players pallet
 */ 
public class HUD : MonoBehaviour 
{
	public bool isValid = false;

	public void updateResourceHUDs(int gold, int resource, int material,int food,int population){
		var huds = GameObject.FindGameObjectsWithTag (Tags.HUD);
		foreach (GameObject o in huds) {
			o.GetComponent<TextMesh>().text = 
				Convert.ToString (	"Materials: " + material + ",\t " +
				                  	"Gold: " + gold + ",\t " +							 
				                    "Food: " + food + ",\t " +
				                    "Population: " + population)+ ",\t " +
									"Environment: " + (resource/10) + "%";
		}
	}
}
