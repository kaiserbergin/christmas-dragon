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

    public GameManager GameManager;

    public UIManager UIManager;
    public SoundManager SoundManager;

    public List<Asteroid> AsteroidPrefabs;

    private List<Asteroid> _asteroids;
    private int _asteroidIndex = 0;

    public List<float> SizeDistribution = new List<float> { .75f, .875f, .95f, 1f };

    public int SpawnRate = 3;

    public float[] TumbleRange = new float[2] { 0.0f, 5.0f };

    public int SmallAsteroidHealth = 1;
    public float[] SmallAsteroidSpeedRange = new float[2] { 20f, 40f };
    public float[] SmallAsteroidSizeRange = new float[2] { 1.25f, 2f };

    public int MediumAsteroidHealth = 2;
    public float[] MediumAsteroidSpeedRange = new float[2] { 20f, 30f };
    public float[] MediumAsteroidSizeRange = new float[2] { 2.5f, 3.25f };

    public int LargeAsteroidHealth = 3;
    public float[] LargeAsteroidSpeedRange = new float[2] { 15f, 25f };
    public float[] LargeAsteroidSizeRange = new float[2] { 3.5f, 5f };

    public int MegaAsteroidHealth = 5;
    public float[] MegaAsteroidSpeedRange = new float[2] { 5f, 10f };
    public float[] MegaAsteroidSizeRange = new float[2] { 7f, 10f };

    public float SpawnDuration = 5.0f;
    public float CurrentSpawnDuration = 0f;
    public List<float> SpawnTimes = new List<float>();

    public int CurrentWave = 0;
    public int MaxWave = 50;



    // Start is called before the first frame update
    void Start()
    {
        _asteroids = new List<Asteroid>();

        foreach (var prefab in AsteroidPrefabs)
        {
            for (int i = 0; i < 100; i++)
            {
                var asteroid = Instantiate(prefab);
                asteroid.UIManager = UIManager;
                asteroid.SoundManager = SoundManager;
                _asteroids.Add((Asteroid)asteroid);
            }
        }

        for (int i = 0; i < _asteroids.Count; i++)
        {
            var temp = _asteroids[i];
            int randomIndex = UnityEngine.Random.Range(i, _asteroids.Count - 1);
            _asteroids[i] = _asteroids[randomIndex];
            _asteroids[randomIndex] = temp;
        }

        BeginNewWave();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpawnDuration += Time.deltaTime;

        if (CurrentSpawnDuration >= 8f || (CurrentSpawnDuration >= SpawnDuration && _asteroids.TrueForAll(x => x.gameObject.activeSelf == false)))
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
        for (int i = 0; i < SpawnRate; i++)
        {
            SpawnTimes.Add(UnityEngine.Random.value * SpawnDuration);
        }

        CurrentSpawnDuration = 0f;
        CurrentWave++;

        if (CurrentWave > MaxWave)
        {
            GameManager.WinGame();
        }
        else
        {
            SetSpawnRate();

            UIManager.SetWave(CurrentWave);
            SoundManager.PlayWave();
        }
    }

    private void SetSpawnDuration()
    {
        if (CurrentWave == 10)
        {
            SpawnDuration += 1f;
        }
        else if (CurrentWave == 20)
        {
            SpawnDuration += 2f;
        }
        else if (CurrentWave == 30)
        {
            SpawnDuration += 5f;
        }
        else if (CurrentWave == 40)
        {
            SpawnDuration += 10f;
        }
    }

    private void SetSpawnRate()
    {
        if (CurrentWave > 2)
        {
            SpawnRate += 2;
        }
        else if (CurrentWave > 9)
        {
            SpawnRate += 4;
        }
        else if (CurrentWave > 19)
        {
            SpawnRate += 6;
        }
        else if (CurrentWave > 29)
        {
            SpawnRate += 8;
        }
        else if (CurrentWave > 39)
        {
            SpawnRate += 10;
        }
    }

    private void ContinueWave()
    {
        for (int i = 0; i < SpawnTimes.Count; i++)
        {
            if (SpawnTimes[i] <= CurrentSpawnDuration)
            {
                SpawnAsteroid();
            }
        }
        SpawnTimes.RemoveAll(x => x <= CurrentSpawnDuration);
    }

    private void SpawnAsteroid()
    {
        var normal = UnityEngine.Random.value;
        var typeIndex = SizeDistribution.FindIndex(x => x >= normal);
        var type = (AsetroidType)typeIndex;
        var asteroid = _asteroids[_asteroidIndex];

        SpawnAsteroid(type, asteroid);
    }

    private void SpawnAsteroid(AsetroidType type, Asteroid asteroid)
    {
        asteroid.transform.position = GetSpawnPoint();

        ActivateAsteroid(type, asteroid);

        if (_asteroidIndex < _asteroids.Count - 1)
            _asteroidIndex++;
        else
            _asteroidIndex = 0;
    }

    private void ActivateAsteroid(AsetroidType type, Asteroid asteroid)
    {
        int health = 1;
        float speed = 0f;
        float size = 0f;

        switch (type)
        {
            case AsetroidType.SMALL:
                health = SmallAsteroidHealth;
                size = UnityEngine.Random.Range(SmallAsteroidSizeRange[0], SmallAsteroidSizeRange[1]);
                speed = UnityEngine.Random.Range(SmallAsteroidSpeedRange[0], SmallAsteroidSpeedRange[1]);
                break;
            case AsetroidType.MEDIUM:
                health = MediumAsteroidHealth;
                size = UnityEngine.Random.Range(MediumAsteroidSizeRange[0], MediumAsteroidSizeRange[1]);
                speed = UnityEngine.Random.Range(MediumAsteroidSpeedRange[0], MediumAsteroidSpeedRange[1]);
                break;
            case AsetroidType.LARGE:
                health = LargeAsteroidHealth;
                size = UnityEngine.Random.Range(LargeAsteroidSizeRange[0], LargeAsteroidSizeRange[1]);
                speed = UnityEngine.Random.Range(LargeAsteroidSpeedRange[0], LargeAsteroidSpeedRange[1]);
                break;
            case AsetroidType.MEGA:
                health = MegaAsteroidHealth;
                size = UnityEngine.Random.Range(MegaAsteroidSizeRange[0], MegaAsteroidSizeRange[1]);
                speed = UnityEngine.Random.Range(MegaAsteroidSpeedRange[0], MegaAsteroidSpeedRange[1]);
                break;
        }

        asteroid.Type = type;
        asteroid.Health = health;
        asteroid.transform.localScale = new Vector3(size, size, size);

        asteroid.gameObject.SetActive(true);

        asteroid.Rigidbody.velocity = Vector3.forward * speed * -1;
        asteroid.Rigidbody.angularVelocity = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(TumbleRange[0], TumbleRange[1]);
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 p;
        p.x = UnityEngine.Random.Range(this.transform.localScale.x * -1, this.transform.localScale.x) * 0.5f;
        p.y = 0f;
        p.z = UnityEngine.Random.Range(this.transform.localScale.z * -1, this.transform.localScale.z) * 0.5f;
        return transform.TransformPoint(p);
    }
}
