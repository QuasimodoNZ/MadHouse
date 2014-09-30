using UnityEngine;
using System.Collections;
using System;

public class HUD : MonoBehaviour 
{
	public bool isValid = false;

	public void updateResourceHUDs(int gold, int resource, int material,int food,int population){
		var huds = GameObject.FindGameObjectsWithTag (Tags.HUD);
		foreach (GameObject o in huds) {
			o.GetComponent<TextMesh>().text = 
				Convert.ToString (	"Gold: " + gold + "\t " +
									"Environment: " + (resource/10) + "%\t " +
									"Materials: " + material + "\t " +
				                    "Food: " + food + "\t " +
				                    "population: " + population);
		}
	}
}
