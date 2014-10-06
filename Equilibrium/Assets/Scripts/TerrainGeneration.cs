using UnityEngine;
using System.Collections;
using System.IO; 
public class TerrainGeneration : MonoBehaviour {




	public string filename;
	// Use this for initialization
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
		


	//GameObject resource = (GameObject) Resources.Load (generateDiffResources(i, j));
	//Vector3 temp = new Vector3(i, j, 1);
	//Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
	//resource.tag = Tags.Resource;


	 void placeTile(float x,float y,char type) {
					string t = getTerrainName (type);
					Vector3 temp = new Vector3(x, y, 2f);
					GameObject resource = (GameObject) Instantiate ((Resources.Load (t)), temp, new Quaternion(0, 0, 0, 0));
					resource.name = t;
					resource.transform.parent = gameObject.transform;
					//resource.tag = Tags.Resource;
				}


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
