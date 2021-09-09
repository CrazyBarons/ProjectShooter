using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Wall : script_Interactable
{

    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RB.velocity = new Vector3(1000f, 0f, 0f);
    }

    public override void PlayerHit(GameObject Player)
    {
        PS.Slow();
        Destroy(gameObject);
        return;
    }
}
