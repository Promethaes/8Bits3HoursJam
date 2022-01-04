using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] float downtime = 0.25f;
    public UnityEvent OnChangeWeapon;
    public UnityEvent OnBeginAttack;
    public UnityEvent OnFinishAttack;

    [Header("References")]
    [SerializeField] Weapon primaryWeapon = null;
    [SerializeField] GameObject ownerEntity = null;

    [HideInInspector] public bool canAttack = true;

    float _internalDowntime = 0.0f;

    Weapon _currentWeapon = null;

    private void Awake()
    {
        primaryWeapon.weaponOwner = ownerEntity;
        _currentWeapon = primaryWeapon;
    }

    private void Update()
    {
        _internalDowntime += Time.deltaTime;
        if (_internalDowntime >= downtime)
            OnFinishAttack.Invoke();
    }

    public void OnFIre(CallbackContext ctx)
    {
        if (_currentWeapon.GetCooldown() > 0.0f || _currentWeapon.IsAttacking() || !ctx.performed)
            return;
        _internalDowntime = 0.0f;
        OnBeginAttack.Invoke();
        _currentWeapon.Attack();
        if (_currentWeapon != primaryWeapon)
            _currentWeapon = primaryWeapon;
    }

    public void SetCurrentWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

}
