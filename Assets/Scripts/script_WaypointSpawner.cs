using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_WaypointSpawner : MonoBehaviour
{

    public GameObject Signal;
    public GameObject FinishLine;

    float runningSpeed;
    int trackLength;
    int currentSignal;

    bool canSpawn = false;
    bool isWaiting = false;

    void Start()
    {
        runningSpeed = script_ParameterLoader.get_runningSpeed();
        trackLength = script_ParameterLoader.get_trackLength();
        currentSignal = trackLength;
    }

    void Update()
    {
        if (!isWaiting)
        {
            if (!canSpawn)
            {
                isWaiting = true;
                StartCoroutine(CoolDown());
            }
            if (canSpawn && currentSignal > 0)
            {
                canSpawn = false;
                SpawnSignal();
            }
            if (canSpawn && currentSignal == 0)
            {
                canSpawn = false;
                SpawnFinish();
            }
        }
    }

    void SpawnSignal()
    {
        Instantiate(Signal, new Vector3(-2932f, 110f, 2436f), Quaternion.identity);
        currentSignal = currentSignal - 1;
        return;
    }

    void SpawnFinish()
    {
        Instantiate(FinishLine, new Vector3(-2932f, 110f, 1460f), Quaternion.identity);
        return;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1000f/runningSpeed);
        canSpawn = true;
        isWaiting = false;
        StopCoroutine(CoolDown());
    }

    public int get_currentSignal()
    {
        return currentSignal + 1;
    }

    void GameStart()
    {
        StopAllCoroutines();
        canSpawn = false;
        isWaiting = false;
        currentSignal = trackLength;
        return;
    }
}
