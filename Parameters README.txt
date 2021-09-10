These parameters are modifiable in a file contained within the assets folder. Here is a basic explanation of what they do and how much you are allowed to tweak them.

-EnemyFrequency is a float number, determining how much time passes between the spawn of the enemies. This time then is modified by a margin of 10% to add a bit of variance to timing.

-WallsFrequency is a float number, determining how much time passes between the spawn of new walls. As with enemies, the time is increased or decreased by a value within 10% of the original number, so that new obstacles are a bit less predictable.

-ProjectileSpeed is a float number, determining the speed of the projectiles shot by the player.

-EnemySpeed is a float number, determining the speed at which the enemies run behind the player. As with walls' and enemies' spawn rate, the value is increased or decreased by 10%, to add a touch of unpredictability to the game.

-RunningSpeed is a float number, with a direct influence on the signals' spawn frequency. Signals spawn with a frequency of one every (1000/RunningSpeed) seconds (assuming that the player has not been slowed).

-HorizontalSpeed is a float number, determining the horizontal speed of the player, influencing the ability to avoid walls.

-ReloadTime is a float number, determining how many seconds have to pass after a shot is fired before firing the next one.

-SlowPercent is a float number, determining how much the player gets slower whenever he touches a wall. (1.0f = 100%)

-TrackLength is an integer number, determining how many signals the player has to pass before the end of the road is reached.

-EnemyTotal is an integer number, determining how many enemies you have to kill before you've won the game.

-StartingEnemies is an integer number, quantifying the number of enemies already on board when the game starts.

-EnemyVolley in an integer number, quantifying the number of enemies spawned every (EnemyFrequency) seconds.