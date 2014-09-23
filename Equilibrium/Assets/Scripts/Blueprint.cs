using UnityEngine;
using System;

using System.Collections;

public class Blueprint : MonoBehaviour
{
		public static float tileSize = 1.0f;

		private ArrayList collidingObjects = new ArrayList ();

		private  Color collidingColour = new Color (
		1.0f, 0.0f, 0.0f, 0.5f);
		private  Color unobstructedColour = new Color (
		0.0f, 1.0f, 0.0f, 0.5f);

		public Material red;
		public Material green;

		private GameObject parent;
		// Use this for initialization
		void Start ()
		{
				//Starts off colliding with the cloned object
			gameObject.renderer.material = red;	
			Update ();

		}
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 pos = parent.transform.position;
				pos.x = RoundOff (pos.x);
				pos.y = RoundOff (pos.y);
				pos.z = 0.0f;
				gameObject.transform.position = pos;
		}

		void OnTriggerEnter (Collider other)
		{
			collidingObjects.Add (other.gameObject);
			if (isColliding ()) {
				gameObject.renderer.material = red;
			}
			Debug.Log (collidingObjects.Count);
		}

		void OnTriggerStay (Collider other)
		{
			if (!collidingObjects.Contains (other.gameObject)){
				collidingObjects.Add (other.gameObject);
			}
			if (isColliding ()) {
				gameObject.renderer.material = red;
			}
		}

		void OnTriggerExit (Collider other)
		{
				collidingObjects.Remove (other.gameObject);	
				if (!isColliding ()) {
						gameObject.renderer.material = green;
				}
			Debug.Log (collidingObjects.Count);
		}

		public bool isColliding ()
		{
				bool colliding = false;
				foreach (var other in collidingObjects) {
					GameObject check = (GameObject)other;
					if(!parent.GetComponent<BuildingTicker>().canCollideWith(check.gameObject) && parent != check.gameObject){
						colliding = true;
						break;
					}
				}

				return colliding;
		}

		public void setParent (GameObject go)
		{
				parent = go;
		}

		public static  float RoundOff (float i)
		{
				return (float)(Math.Round (i / tileSize)) * tileSize;
		}
}
