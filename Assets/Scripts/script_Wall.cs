using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Wall : script_Interactable
{

    public override void PlayerHit(GameObject Player)
    {
        PS.Slow();
        Destroy(gameObject);
        return;
    }
}
