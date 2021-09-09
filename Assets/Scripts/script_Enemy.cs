using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Enemy : MonoBehaviour
{

    //This Function makes it so that whenever an enemy collides with the player, the virtual function is called. This function is then
    //implemented differently, depending on the enemy. (Some enemies might just slow you, or maybe obscure the player's vision in a certain way
    //for a short period of time)
    //(By the way, this class and the interactable class are basically the same now, but since the project has to be done with the perspective of a future
    //expansion, so I think it's better to keep them separated, since there are a lot of possibilities to differentiate them)

    public Transform P;
    public script_Player PS;
    public script_MainMenu MM;

    private void Awake()
    {
        MM = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<script_MainMenu>();
        P = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<script_Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerHit(collider.gameObject);
        }
    }

    public virtual void PlayerHit(GameObject Player)
    {
        return;
    }

    void GameStart()
    {
        Destroy(gameObject);
        return;
    }
}
