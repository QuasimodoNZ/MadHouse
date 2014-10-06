using UnityEngine;
using System.Collections;

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
						transform.position += new Vector3 (0, 0, 0);// scroll * Time.deltaTime); 
						alpha -= Time.deltaTime / duration;
						Color previous = renderer.material.color;
						renderer.material.color = new Color (previous.r, previous.g, previous.b, alpha);      
				} else {
						Destroy (gameObject);
				}
		}


		public static void SpawnPts (string message, float x, float y)
		{
				GameObject instance = Resources.Load <GameObject> ("Fading Popup");
				x = Mathf.Clamp (x, -14.3f, 14.3f); // clamp position to screen to ensure
				y = Mathf.Clamp (y, -7.2f, 7.2f);  // the string will be visible
				float angle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;
				//Quaternion q = new Quaternion (0, 0, angle - Mathf.PI / 2, 1);
				GameObject gui = Instantiate (instance, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
				gui.transform.Rotate (0, 0, angle + 90);
				gui.GetComponent<TextMesh> ().text = "Message";
		}
}
