﻿using UnityEngine;
using System.Collections;

public class City : BuildingTicker
{
		private int upkeep, enviormentDamage, foodConsumed;

		public void tick (Clock c)
		{
			c.eatFood (upkeep);
			c.spendGold (enviormentDamage);
			c.ruinEnvironment (enviormentDamage);
		}
}
