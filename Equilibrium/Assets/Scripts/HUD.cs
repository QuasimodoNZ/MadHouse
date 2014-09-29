using UnityEngine;
using System.Collections;
using System;

public class HUD : MonoBehaviour 
{
	public bool isValid = false;

	public void updateResourceHUDs(int gold, int resource, int material,int food){
		var huds = GameObject.FindGameObjectsWithTag (Tags.HUD);
		foreach (GameObject o in huds) {
			o.GetComponent<TextMesh>().text = 
				Convert.ToString (	"Gold: " + gold + "\t " +
									"Resources: " + resource + "\t " +
									"Materials: " + material + "\t " +
				                  	"Food: " + food );
		}
	}
}
