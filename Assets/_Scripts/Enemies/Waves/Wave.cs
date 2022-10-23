public class Wave 
{
    public int enemyIndex;
    public int EnemyToSpawnCount;
    public int[] arraySpawnPoint;
    public float time;

    public Wave(int enemyIndex, int EnemyToSpawnCount, int[] arraySpawnPoint, float time)
    {
        this.enemyIndex = enemyIndex;
        this.EnemyToSpawnCount = EnemyToSpawnCount;
        this.arraySpawnPoint = arraySpawnPoint;
        this.time = time;
    }
}
