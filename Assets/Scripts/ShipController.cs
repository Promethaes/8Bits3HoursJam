using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class ShipController : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float maxSpeed = 10.0f;
    public float rotationSpeed = 1.0f;

    [Header("References")]
    [SerializeField] Rigidbody2D _rigidbody = null;

    Vector2 _moveVec = new Vector2();

    private void Update()
    {


    }
    private void LateUpdate()
    {

    }
    private void FixedUpdate()
    {
        if (_moveVec.x != 0.0f)
            _rigidbody.MoveRotation(_rigidbody.rotation - _moveVec.x*rotationSpeed);

        var dir = moveSpeed * -_rigidbody.gameObject.transform.up;
        if (_moveVec.y > 0.0f)
            _rigidbody.AddForce(dir);
        else if (_moveVec.y < 0.0f)
            _rigidbody.AddForce(-_rigidbody.velocity);

        if (_rigidbody.velocity.magnitude > maxSpeed)
        {
            _rigidbody.AddForce(-_rigidbody.velocity);
        }
    }

    public void OnMove(CallbackContext ctx)
    {
        _moveVec = ctx.ReadValue<Vector2>();
    }
    public void OnPause(CallbackContext ctx)
    {

    }
}
