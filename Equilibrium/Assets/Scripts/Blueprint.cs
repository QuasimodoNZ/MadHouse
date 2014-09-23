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
		Debug.Log ("OnTriggerEnter " + other);
				if (other.gameObject.tag == Tags.Built) { 
						gameObject.renderer.material =red;		
						collidingObjects.Add (other.gameObject);
				}
		}
		void OnTriggerStay (Collider other)
		{
		Debug.Log ("OnTriggerStay " + other);
				if (other.gameObject.tag == Tags.Built) {
						gameObject.renderer.material = red;		
						if (!collidingObjects.Contains (other.gameObject))
								collidingObjects.Add (other.gameObject);
				}
		}

		void OnTriggerExit (Collider other)
		{
		Debug.Log ("OnTriggerExit " + other);
				collidingObjects.Remove (other.gameObject);	
				if (!isColliding ())
						gameObject.renderer.material = green;
		}

		public bool isColliding ()
		{
				bool colliding = false;

				foreach (var other in collidingObjects) {
					GameObject check = (GameObject)other;
					if (check.gameObject == null) continue;
					if(!parent.GetComponent<BuildingTicker>().canCollideWith(check.gameObject)){
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
