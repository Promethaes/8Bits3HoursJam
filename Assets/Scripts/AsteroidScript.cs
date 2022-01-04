using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField] float maxSpawnSpeed = 1.0f;
    [Header("References")]
    [SerializeField] GameObject asteroidPrefab;
    [HideInInspector] public int size = 3;

    float _zRot = 0.0f;

    private void Start()
    {
        _zRot = Random.Range(-1.0f, 1.0f);
        transform.Rotate(-Vector3.forward, Random.Range(-360.0f, 360.0f));
        GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(0.1f, maxSpawnSpeed), ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Rotate(-Vector3.forward * _zRot);
    }

    public void OnDie()
    {
        if (size == 1)
        {
            ScoreManager.AddScore(100.0f);
            Destroy(gameObject);
            return;
        }
        var asOne = GameObject.Instantiate(asteroidPrefab);
        var asTwo = GameObject.Instantiate(asteroidPrefab);
        asOne.GetComponent<AsteroidScript>().size = size - 1;
        asTwo.GetComponent<AsteroidScript>().size = size - 1;

        asOne.transform.localScale = asOne.transform.localScale / 2.0f;
        asTwo.transform.localScale = asTwo.transform.localScale / 2.0f;

        asOne.transform.position = transform.position;
        asTwo.transform.position = transform.position;

        Destroy(gameObject);
    }
}
