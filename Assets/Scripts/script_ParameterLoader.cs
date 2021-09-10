using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class script_ParameterLoader
{

    readonly static float EnemyFrequency = 3f;
    readonly static float WallsFrequency = 3f;
    readonly static float ProjectileSpeed = 1850f;
    readonly static float EnemySpeed = 300f;
    readonly static float RunningSpeed = 200f;
    readonly static float HorizontalSpeed = 500f;
    readonly static float ReloadTime = 1.0f;
    readonly static float SlowPercent = 0.5f;
    readonly static int TrackLength = 5;
    readonly static int EnemyTotal = 15;
    readonly static int StartingEnemy = 5;
    readonly static int EnemyVolley = 1;

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

    public static int get_trackLength()
    {
        return TrackLength;
    }

    public static float get_slowPercent()
    {
        return SlowPercent;
    }

    public static int get_enemyTotal()
    {
        return EnemyTotal;
    }

    public static int get_startingEnemy()
    {
        return StartingEnemy;
    }

    public static int get_enemyVolley()
    {
        return EnemyVolley;
    }
}