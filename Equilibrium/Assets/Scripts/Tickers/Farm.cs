using UnityEngine;
using System.Collections;

public class Farm : BuildingTicker
{
	private BuildingCosts buildings = new BuildingCosts();


	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.FarmDamage);
				c.generateGold (buildings.FarmGold);
				c.generateFood (buildings.FarmFood);
				c.generateMaterials (buildings.FarmMaterials);
		}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Farmland")
			return true;
		
		return false;
		}
}
