public  class DataForGame
{
    public static float delayTime = 7f;
    public static float EnemiesSpeed = -0.1f;
    public static float LaserSpeedFactor = 30f;
    public static int score = 0;
    public static float  xMax=7.5f;
    public static float xMin=-7.5f;
    public static float ySpawn = 5f;
    public static int limitScoreAfterChange=2;
    public static void increaseEnemiesSpeed()
    {

        EnemiesSpeed -= 0.05f;
    }

    public static void increaseLaserSpeedFactor()
    {
        LaserSpeedFactor += 5;
    }

    public static void decreaseDelayTime()
    {
        if (delayTime < 3) return;
        delayTime -= 1;
    }
}
