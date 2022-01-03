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
    }

    private void Update()
    {
        transform.Rotate(-Vector3.forward * _zRot);
    }

    public void OnDie()
    {
        var asOne = GameObject.Instantiate(asteroidPrefab);
        var asTwo = GameObject.Instantiate(asteroidPrefab);
        asOne.GetComponent<AsteroidScript>().size = size - 1;
        asTwo.GetComponent<AsteroidScript>().size = size - 1;
        
        asOne.transform.localScale = asOne.transform.localScale / 2.0f;
        asTwo.transform.localScale = asTwo.transform.localScale / 2.0f;
        
        asOne.transform.position = transform.position;
        asTwo.transform.position = transform.position;

        asOne.transform.Rotate(-Vector3.forward,Random.Range(0.0f,360.0f));
        asOne.GetComponent<Rigidbody2D>().AddForce(asOne.transform.up*maxSpawnSpeed);

        asTwo.transform.Rotate(-Vector3.forward,Random.Range(0.0f,360.0f));
        asTwo.GetComponent<Rigidbody2D>().AddForce(asTwo.transform.up*maxSpawnSpeed);
    }
}
