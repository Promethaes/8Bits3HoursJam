using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponDrop : MonoBehaviour
{
    [SerializeField] UnityEvent OnPickup = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        OnPickup.Invoke();
        Destroy(gameObject);
    }
}
