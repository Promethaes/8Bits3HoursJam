using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : Health
{
    public UnityEvent OnBreakShield;
    public bool shield = false;

    public void GiveShield()
    {
        shield = true;
    }

    public override void TakeDamage(float damage)
    {
        if (shield)
        {
            shield = false;
            OnBreakShield.Invoke();
            return;
        }
        if (health <= 0.0f)
            return;
        base.TakeDamage(damage);
    }
}
