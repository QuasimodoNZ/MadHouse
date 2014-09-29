﻿using UnityEngine;
using System.Collections;

public class Farm : BuildingTicker
{
	private int enviroDamage = 40;
	private int gold = 5;
	private int foodGenerated = 30;
	private int materialsBuild = 8;


	public override void tick (Clock c)
		{
				//c.eatFood (upkeep);
				//c.spendGold (enviormentDamage);
				c.ruinEnvironment (enviroDamage);
				c.generateGold (gold);
				c.generateFood (foodGenerated);
		}
	public override bool canCollideWith (GameObject other){
		
		if (other.tag.Equals (Tags.Built))
			return false;
		
		
		if (other.name == "Farmland")
			return true;
		
		return false;
		}
}
