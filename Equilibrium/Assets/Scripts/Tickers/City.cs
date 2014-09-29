using UnityEngine;
using System.Collections;

public class City : BuildingTicker
{
		private int enviroDamage = 20;
		private int buildMaterials = 20;
		private int goldPerTurn = 40;

		public override void tick (Clock c)
		{
			c.eatFood (upkeep);
			c.spendGold (enviormentDamage);
			c.ruinEnvironment (enviormentDamage);
		}

	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name != "Trees" && other.name != "Mountain" && other.name != "Water" && other.name != "Fish")
			return true;
		
		return false;
	}
}
