using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_EnemyCollision : MonoBehaviour
{
	void Start()
	{
		//Ignoring collisions with Player, Weapons and other Enemies
		//This works for enemies that must hit the player, but still touch floors etc.
		Physics.IgnoreLayerCollision(7, 6, true);
		Physics.IgnoreLayerCollision(7, 7, true);
		Physics.IgnoreLayerCollision(7, 8, true);
	}
}
