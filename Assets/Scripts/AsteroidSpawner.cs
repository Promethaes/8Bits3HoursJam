using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Range(0.1f, 1.0f)]
    [SerializeField] float spawnTimer = 1.0f;
    [SerializeField] int maxAsteroids = 5;
    [Header("References")]
    [SerializeField] GameObject asteroidPrefab = null;

    List<GameObject> _asteroids = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(0.1f, spawnTimer);
        IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTimer);
                if (_asteroids.Count < maxAsteroids)
                    _asteroids.Add(GameObject.Instantiate(asteroidPrefab, transform.position, transform.rotation));
            }
        }
        StartCoroutine(Spawn());
    }
}
