using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Interactable : MonoBehaviour
{

    //This Function makes it so that whenever an interactable collides with the player, the virtual function is called. This function is then
    //implemented differently, depending on the object. (The walls for example slow you down, while if you touch the finish line you win the game)
    //(By the way, this class and the enemy class are basically the same now, but since the project has to be done with the perspective of a future
    //expansion, so I think it's better to keep them separated, since there are a lot of possibilities to differentiate them)

    public script_MainMenu MM;

    private void Awake()
    {
        MM = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<script_MainMenu>();
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
}
