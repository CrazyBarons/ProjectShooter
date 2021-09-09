using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_FinishLine : script_Interactable
{
    Rigidbody RB;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        speed = script_ParameterLoader.get_runningSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(speed * 10f, 0f, 0f);
    }

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