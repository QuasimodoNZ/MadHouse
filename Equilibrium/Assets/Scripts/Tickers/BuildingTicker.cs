using UnityEngine;
using System.Collections;

public abstract class BuildingTicker : MonoBehaviour
{		
	abstract public void tick (Clock c);

	public abstract bool canCollideWith (GameObject other);

}
