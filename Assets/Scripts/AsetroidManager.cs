using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AsetroidType
{
    SMALL = 0,
    MEDIUM = 1,
    LARGE = 2,
    MEGA = 3
}

public class AsetroidManager : MonoBehaviour
{
    public Collider SpawnCollider;

    public List<GameObject> AsteroidPrefabs;

    private List<GameObject> _asteroids;
    private int _asteroidIndex;

    public List<float> SizeDistribution = new List<float> { .75f, .875f, 95f, 100f };

    public int SpawnRate = 3;

    public int SmallAsteroidHealth = 1;
    public float[] SmallAsteroidSpeedRange = new float[2] { 20f, 40f };
    public float[] SmallAsteroidSizeRange = new float[2] { .75f, 1.25f };

    public int MediumAsteroidHealth = 2;
    public float[] MediumAsteroidSpeedRange = new float[2] { 20f, 30f };
    public float[] MediumAsteroidSizeRange = new float[2] { 1.5f, 2.0f };

    public int LargeAsteroidHealth = 3;
    public float[] LargeAsteroidSpeedRange = new float[2] { 15f, 25f };
    public float[] LargeAsteroidSizeRange = new float[2] { 3.0f, 3.5f };

    public int MegaAsteroidHealth = 5;
    public float[] MegaAsteroidSpeedRange = new float[2] { 5f, 10f };
    public float[] MegaAsteroidSizeRange = new float[2] { 5.0f, 7.0f };

    public float SpawnDuration = 5.0f;
    public float CurrentSpawnDuration = 0f;
    public List<float> SpawnTimes = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        var asteroids = new List<GameObject>();

        foreach (var asteroid in AsteroidPrefabs)
        {
            for (int i = 0; i < 5; i++) 
            {
                asteroids.Add(asteroid);
            }
        }

        for (int i = 0; i < asteroids.Count; i++) 
        {
            var temp = asteroids[i];
            int randomIndex = UnityEngine.Random.Range(i, asteroids.Count);
            asteroids[i] = asteroids[randomIndex];
            asteroids[randomIndex] = temp;
        }

        BeginNewWave();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpawnDuration += Time.deltaTime;

        if (CurrentSpawnDuration >= SpawnDuration)
        {
            BeginNewWave();
        }
        else
        {
            ContinueWave();
        }
    }

    private void BeginNewWave()
    {
        SpawnTimes = new List<float>();
        for (int i = 0; i < SpawnRate; i++) {
            SpawnTimes.Add(UnityEngine.Random.value * SpawnRate);
            CurrentSpawnDuration = 0f;
        }        
    }

    private void ContinueWave()
    {
        for (int i = 0; i < SpawnTimes.Count; i++)
        {
            if (SpawnTimes[i] <= CurrentSpawnDuration)
            {
                Debug.Log("Spawn an asteroid");
            }
        }
        SpawnTimes.RemoveAll(x => x <= CurrentSpawnDuration);
    }
}
