using UnityEngine;
using System.Collections;

public class Fishing : BuildingTicker
{
		private int enviroDamage = 15;
		private int gold = 10;
		private int foodGenerated= 20;
		private int materialsBuild = 5;
	
	public override void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
	}	

	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Fish")
			return true;
		
		return false;
		}
}
