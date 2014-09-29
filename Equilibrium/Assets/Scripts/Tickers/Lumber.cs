using UnityEngine;
using System.Collections;

public class Lumber : BuildingTicker
{
	private int enviroDamage = 5;
	private int gold = 7;
	private int materialsBuild = 10;
	private int materialsGenerated = 6;
	
	public override void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
	}
	public override bool canCollideWith (GameObject other){

	    if (other.tag.Equals (Tags.Built))
			return false;


		if (other.name == "Trees")
			return true;

		return false;
		}
}
