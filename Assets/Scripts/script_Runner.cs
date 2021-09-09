using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Runner : script_Enemy
{

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = script_ParameterLoader.get_enemySpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PlayerHit(GameObject Player)
    {
        MM.Lose();
        return;
    }
}
