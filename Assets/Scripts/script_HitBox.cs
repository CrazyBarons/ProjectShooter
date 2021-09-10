using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_HitBox : script_RelativeSpeed
{

    public script_KillCounter KC;

    public void Awake()
    {
        KC = GameObject.Find("KillCounter").GetComponent<script_KillCounter>();
    }

    //This Function makes it so that whenever a player weapon collides with an enemy, a specific function is called. This function is then
    //implemented differently, depending on the weapon. (e.g. bullet kill enemies, but other weapon may only slow them or have other effects)
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyHit(collider.gameObject);
        }
    }

    public virtual void EnemyHit(GameObject Enemy)
    {
        KC.KilledOne();
        Destroy(Enemy);
        return;
    }
}
