using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public GameObject weaponOwner = null;

    [Tooltip("-1 for infinite")]
    [SerializeField] protected float cooldown = 0.0f;

    public UnityEvent OnAttack;
    public UnityEvent OnEnableWeapon;
    public UnityEvent OnDisableWeapon;

    float _cooldown = 0.0f;
    protected bool _attacking = false;

    private void OnEnable()
    {
        _cooldown = cooldown;
        OnEnableWeapon.Invoke();
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    private void OnDisable()
    {
        OnDisableWeapon.Invoke();
    }

    public float GetCooldown()
    {
        return _cooldown;
    }

    public bool IsAttacking()
    {
        return _attacking;
    }

    public virtual void Attack()
    {
        _cooldown = cooldown;
        OnAttack.Invoke();
    }

}
