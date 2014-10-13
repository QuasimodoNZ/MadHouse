/*
Equilibirium, a game simulator for balancing economic progress and environmental collapse.
Copyright (C) 2014, Mad House Studios.
		
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
		
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
			
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;
using System.Collections;

/**
 * base class for all buildings
 */ 
public abstract class BuildingTicker : MonoBehaviour
{		
	/**
	 * has the effects of each building to different parts of the game
	 */ 
	abstract public void tick (Clock c);

	/**
	 * collider that specifies which tiles the building can be built on
	 */ 
	public abstract bool canCollideWith (GameObject other);

}
