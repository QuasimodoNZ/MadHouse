using UnityEngine;
using System.Collections;

public class Mine :BuildingTicker
{
		private int enviroDamage = 10;
		private int gold = 25;
		private int materialsBuild = 8;
		private int materialsGenerated = 19;
	
	public override void tick (Clock c)
		{
				c.eatFood (upkeep);
				c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviormentDamage);
	}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Mountain" || other.name == "Iron Ore" || other.name == "Copper Ore" || other.name == "Gold Ore" || other.name == "Coal")
			return true;
		
		return false;
		}
}
