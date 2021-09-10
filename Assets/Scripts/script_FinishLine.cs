using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_FinishLine : script_Interactable
{

    public override void PlayerHit(GameObject Player)
    {
        MM.Win();
        Destroy(gameObject);
        return;
    }

    void StartGame()
    {
        Destroy(gameObject);
        return;
    }
}