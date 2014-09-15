using UnityEngine;
using System.Collections;
using System.IO; 
public class TerrainGeneration : MonoBehaviour {




	public string filename;
	// Use this for initialization
	void Start () {
			
				string[] lines = File.ReadAllLines (Application.dataPath + "/" + filename);
				for (int i = 0; i < lines.Length; ++i) {
						char[] c = lines[i].ToCharArray ();

						for (int j = 0; j < c.Length; ++j) {
							
				placeTile((float)(j-15.5),(float)(i-8.5),c[j]);
								}
						}
				}
		


	//GameObject resource = (GameObject) Resources.Load (generateDiffResources(i, j));
	//Vector3 temp = new Vector3(i, j, 1);
	//Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
	//resource.tag = Tags.Resource;


	 void placeTile(float x,float y,char type) {
					string t = getTerrainName (type);
		Debug.Log ("terrain: " +t);
					GameObject resource = (GameObject) Resources.Load (t);
					Vector3 temp = new Vector3(x, y, 2f);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
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
				return"Coal";
		case 'M':
			return "Mountain";
		case 'A':
			return "Gold Ore";
		

				}
		//throw new error("Could not fin the tiletype in the Map");
		Debug.Log ("didnt find type for : " + type);
		return "Trees";
	}


	// Update is called once per frame
	void Update () {

	}
}
