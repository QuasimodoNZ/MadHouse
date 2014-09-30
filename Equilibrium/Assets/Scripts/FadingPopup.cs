using UnityEngine;
using System.Collections;

public class FadingPopup: MonoBehaviour
{

		public Color color = new Color (0.8f, 0.8f, 0f, 1.0f);
		public float scroll = 0.05f;  // scrolling velocity
		public float duration = 100.5f; // time to die
		public float alpha;


		// Use this for initialization
		void Start ()
		{
				guiText.material.color = color; // set text color
				alpha = 1f;

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (alpha > 0) {
						transform.position += new Vector3 (0, 0, scroll * Time.deltaTime); 
						alpha -= Time.deltaTime / duration;
						Color previous = guiText.material.color;
						guiText.material.color = new Color (previous.r, previous.g, previous.b, alpha);      
				} else {
						Destroy (gameObject);
				}
		}


		public static void SpawnPts (string message, float x, float y)
		{
				Debug.Log (Resources.Load ("ScrollingText") as Transform);
				Transform spawnTransform = Resources.Load ("ScrollingText") as Transform;
				x = Mathf.Clamp (x, 0.05f, 0.95f); // clamp position to screen to ensure
				y = Mathf.Clamp (y, 0.05f, 0.9f);  // the string will be visible
				Transform gui = Instantiate (spawnTransform, new Vector3 (x, y, 0), Quaternion.identity) as Transform;
				gui.guiText.text = message;
		}
}
