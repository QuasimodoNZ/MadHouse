using UnityEngine;
using System.Collections;

public class Factory : BuildingTicker
{
		private int enviroDamage = 25;
		private int materialsBuild = 15;
		private int gold = 30;
		private int bonus = .1;	//increases generation of materials of all buildings by 10%
	
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
