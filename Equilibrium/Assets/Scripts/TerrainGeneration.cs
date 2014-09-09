using UnityEngine;
using System.Collections;

public class TerrainGeneration : MonoBehaviour {




	public string filename;
	// Use this for initialization
	void Start () {

				string[] lines = System.IO.File.ReadAllLines (filename);
				for (int i = 0; i < lines.Length; ++i) {
						char[] c = lines[i].ToCharArray ();

						for (int j = 0; j < c.Length; ++j) {
							
								placeTile(i,j,c[j]);
								}
						}
				}
		

	 void placeTile(int x,int y,char type) {
					GameObject resource = (GameObject) Resources.Load (getTerrainName(type));
					Vector3 temp = new Vector3(x, y, 2);
					Instantiate(resource, temp, new Quaternion(0, 0, 0, 0));
					//resource.tag = Tags.Resource;
				}


	private string getTerrainName(char type)
	{
		switch (type) {
				case 'w':
						return "water";
				}
		return "";

	}


	// Update is called once per frame
	void Update () {

	}
}
