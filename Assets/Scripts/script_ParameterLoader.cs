using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class script_ParameterLoader
{

    readonly static float EnemyFrequency = 2f;
    readonly static float WallsFrequency = 3f;
    readonly static float ProjectileSpeed = 1850f;
    readonly static float EnemySpeed = 300f;
    readonly static float RunningSpeed = 2f;
    readonly static float HorizontalSpeed = 500f;
    readonly static float ReloadTime = 1.5f;
    readonly static float PlayerSpeed = 100f;
    readonly static float SlowPercent = 0.5f;
    readonly static int TrackLength = 2;

    public static float get_enemyFrequency()
    {
        return EnemyFrequency;
    }

    public static float get_wallsFrequency()
    {
        return WallsFrequency;
    }

    public static float get_projectileSpeed()
    {
        return ProjectileSpeed;
    }

    public static float get_enemySpeed()
    {
        return EnemySpeed;
    }

    public static float get_runningSpeed()
    {
        return RunningSpeed;
    }

    public static float get_horizontalSpeed()
    {
        return HorizontalSpeed;
    }

    public static float get_reloadTime()
    {
        return ReloadTime;
    }

    public static float get_trackLength()
    {
        return TrackLength;
    }

    public static float get_playerSpeed()
    {
        return PlayerSpeed;
    }

    public static float get_slowPercent()
    {
        return SlowPercent;
    }
}