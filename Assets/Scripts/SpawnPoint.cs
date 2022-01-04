using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    [Header("References")]
    public Transform spawnPoint;
    public GameObject ship;
    public int lives = 3;

    public UnityEvent OnGameOver;
    public UnityEvent OnRespawn;
    public void RespawnPlayer()
    {
        IEnumerator Respawn()
        {
            ship.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ship.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            yield return new WaitForSeconds(1.0f);
            lives--;
            ship.GetComponent<Health>().SetToMaxHealth();

            if (lives == 0)
            {
                OnGameOver.Invoke();
                yield return new WaitForSeconds(1.0f);
            }
            else{
                ship.transform.position = spawnPoint.position;
                OnRespawn.Invoke();
            }
        }
        StartCoroutine(Respawn());
    }

}
