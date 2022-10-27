using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public enum SpawnVariations {LeftWave, RightWave, SingleRandom };
    public SpawnVariations spawnVariant;

    //public static int[] ArraySpawnPoints_1_1 = {1,2,3,4,5,6,16,15,14,13,12,11,7,8,9,10,9,8,7,6};
    //public static int[] ArraySpawnPoints_1_2 = { 2, 4, 6, 8, 10, 12};

    public static int[] leftWave = { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17};
    public static int[] rightWave = { 17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0};
    public static int[] singleRandom = { Random.Range(0, 18)};

    
}


    


