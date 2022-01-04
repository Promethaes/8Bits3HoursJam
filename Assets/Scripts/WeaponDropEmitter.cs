using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponDropEmitter : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] float dropChance = 1.0f;
    public int dropGoal = 5;
    static int _goalNum = 0;

    public void TryDropWeapon()
    {
        _goalNum++;
        if (_goalNum != dropGoal)
            return;
        _goalNum = 0;
        GameObject w = WeaponDropManager.GetSpawnedWeapon();
        if (w == null)
            return;
        var nw = GameObject.Instantiate(w);
        nw.transform.position = transform.position;
    }
}
