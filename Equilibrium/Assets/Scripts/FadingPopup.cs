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
 * allows any object to generate text on the screen, aligned towards the centre
 */ 
public class FadingPopup: MonoBehaviour
{

		public Color color = new Color (0.8f, 0.8f, 0f, 1.0f);
		public float scroll = 0.05f;  // scrolling velocity
		public float duration = 3f; // time to die
		public float alpha;


		// Use this for initialization
		void Start ()
		{
				renderer.material.color = color; // set text color
				alpha = 1f;

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (alpha > 0) {
						transform.position += new Vector3 (0, scroll * Time.deltaTime, 0);//  
						alpha -= Time.deltaTime / duration;
						Color previous = renderer.material.color;
						renderer.material.color = new Color (previous.r, previous.g, previous.b, alpha);      
				} else {
						Destroy (gameObject);
				}
		}


		public static void SpawnPopup (string message, float x, float y, Color colour)
		{
				GameObject instance = Resources.Load <GameObject> ("Fading Popup");
				x = Mathf.Clamp (x, -14.3f, 14.3f); // clamp position to screen to ensure
				y = Mathf.Clamp (y, -7.2f, 7.2f);  // the string will be visible
				float angle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;
				GameObject gui = Instantiate (instance, new Vector3 (x, y, -12), Quaternion.identity) as GameObject;
				gui.GetComponent<TextMesh>().color = colour;
				gui.transform.Rotate (0, 0, angle + 90);
				gui.GetComponent<TextMesh> ().text = message;
		}
}
