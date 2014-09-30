using UnityEngine;
using System.Collections;

public class Lumber : BuildingTicker
{
	private BuildingCosts buildings = new BuildingCosts();
	
	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (buildings.LumberDamage);
				c.generateGold (buildings.LumberGold);
				c.generateMaterials (buildings.LumberMaterials);
	}
	public override bool canCollideWith (GameObject other){

	    if (other.tag.Equals (Tags.Built))
			return false;


		if (other.name == "Trees")
			return true;

		return false;
		}
}
