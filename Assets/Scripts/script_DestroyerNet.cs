using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_DestroyerNet : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }

}
