using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Wall : script_Interactable
{

    Rigidbody RB;

    float speed;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        speed = script_ParameterLoader.get_runningSpeed();
    }

    void Update()
    {
        RB.velocity = new Vector3(speed * 10f, 0f, 0f);
    }

    public override void PlayerHit(GameObject Player)
    {
        PS.Slow();
        Destroy(gameObject);
        return;
    }
}
