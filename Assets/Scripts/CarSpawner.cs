using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public float spawnDelay = 0.3f;

	public GameObject car;

	public Transform[] spawnPoints;

	float nextTimeToSpawn = 0f;

    private void Start()
    {
        spawnDelay = Settings.SpawnDelay;
    }

    void Update ()
	{
        if (nextTimeToSpawn <= Time.time)
		{
			SpawnCar();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

    private void FixedUpdate()
    {
        spawnDelay = spawnDelay = Settings.SpawnDelay;
    }

    void SpawnCar ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[randomIndex];

		Instantiate(car, spawnPoint.position, spawnPoint.rotation);
	}

}
