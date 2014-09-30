using UnityEngine;
using System.Collections;

public class Mine :BuildingTicker
{
		private BuildingCosts buildings = new BuildingCosts();
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.MineDamage);
				c.generateGold (buildings.MineGold);
				c.generateMaterials (buildings.MineMaterials);
	}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Mountain" || other.name == "Iron Ore" || other.name == "Copper Ore" || other.name == "Gold Ore" || other.name == "Coal")
			return true;
		
		return false;
		}
}
