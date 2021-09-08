using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_ParameterLoader : MonoBehaviour
{

    readonly float EnemyFrequency = 2f;
    readonly float WallsFrequency = 2f;
    readonly float ProjectileSpeed = 2f;
    readonly float EnemySpeed = 2f;
    readonly float RunningSpeed = 2f;
    readonly float HorizontalSpeed = 2f;
    readonly float ReloadRime = 2f;
    readonly int Tracklength = 2;

    public float get_enemyFrequency()
    {
        return EnemyFrequency;
    }

    public float get_wallsFrequency()
    {
        return WallsFrequency;
    }

    public float get_projectileSpeed()
    {
        return ProjectileSpeed;
    }

    public float get_enemySpeed()
    {
        return EnemySpeed;
    }

    public float get_runningSpeed()
    {
        return RunningSpeed;
    }

    public float get_horizontalSpeed()
    {
        return HorizontalSpeed;
    }

    public float get_reloadRime()
    {
        return ReloadRime;
    }

    public float get_tracklength()
    {
        return Tracklength;
    }

}
