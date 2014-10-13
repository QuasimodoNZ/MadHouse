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
using System.IO; 

/*
 * reads in the map from a text file and creates it
 */ 
public class TerrainGeneration : MonoBehaviour {

	public string filename;
	// Use this for initialization
	//reads in the file.
	void Start () {
		TextAsset mytext = Resources.Load ("GameMap") as TextAsset;
		string load = mytext.text;
		Debug.Log (load);
		string[] lines = load.Split ("\n"[0]);
		Debug.Log (lines.GetLength (0));
				for (int i = 0; i < lines.Length; ++i) {
						char[] c = lines[i].ToCharArray ();

						for (int j = 0; j < c.Length; ++j) {
							if (c[j] == '\r'){
								Debug.Log("Caught it!");
				} else {
							placeTile((float)(j-16f),(float)(i-9f),c[j]);
				}
								}
						}
				}

	/*
	 * creates and places the relevant tile
	 */ 
	 void placeTile(float x,float y,char type) {
					string t = getTerrainName (type);
					Vector3 temp = new Vector3(x, y, 2f);
					GameObject resource = (GameObject) Instantiate ((Resources.Load (t)), temp, new Quaternion(0, 0, 0, 0));
					resource.name = t;
					resource.transform.parent = gameObject.transform;
					//resource.tag = Tags.Resource;
				}

	/*
	 * converts letters in the text file to resource names.
	 */ 
	private string getTerrainName(char type)
	{
		switch (type) {
				case 'W':
			return "Water";
		case 'O':
			return "Oil";
		case 'G':
			return "Grass";
		case 'T':
			return "Trees";
		case 'F':
			return "Farmland";
		case 'I':
			return "Iron Ore";
		case 'S':
			return "Fish";
		case'C':
			return"Copper Ore";
		case 'M':
			return "Mountain";
		case 'A':
			return "Gold Ore";
		case 'L' :
			return "Coal";
		case '\n' :
			Debug.Log ("Got a newline!");
				break;
		case '\r' :
			Debug.Log ("Got a return!");
				break;
				}

		Debug.Log ("didnt find type for : " + type);
		throw new System.Exception("Could not find the tiletype in the Map");


	}


	// Update is called once per frame
	void Update () {

	}
}
