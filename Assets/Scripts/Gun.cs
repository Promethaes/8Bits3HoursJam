using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] int poolSize = 2;
    [SerializeField] float bulletSpeed = 5.0f;
    [SerializeField] bool setInactiveOnFire = true;


    [Header("References")]
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] List<Transform> bulletEmitterPoints = new List<Transform>();

    List<GameObject> _bulletPool = new List<GameObject>();

    int _index = 0;
    private void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {
            _bulletPool.Add(GameObject.Instantiate(bulletPrefab));
            _bulletPool[_bulletPool.Count - 1].SetActive(false);
        }
    }

    public override void Attack()
    {
        gameObject.SetActive(!setInactiveOnFire);
        foreach (var bep in bulletEmitterPoints)
        {
            GameObject bullet = null;
            bullet = _bulletPool[_index];
            _index = (_index + 1) % _bulletPool.Count;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            bullet.transform.rotation = bep.transform.rotation;
            bullet.transform.position = bep.transform.position;
            bullet.transform.position = bullet.transform.position - bep.transform.up;

            var dir = bep.transform.position - bullet.transform.position;
            dir = -dir.normalized;
            bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        }
        base.Attack();
    }
}
