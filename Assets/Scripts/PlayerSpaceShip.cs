using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float maxSpeed = 100.0f;
    [SerializeField]
    float acceleration = 300.0f;
    [SerializeField]
    float brakingCoefficient = 0.05f;

    [Header("Shooting")]
    [SerializeField]
    GameObject projectileFab;

    [Header("Controls")]
    [SerializeField]
    InputActionReference move;
    [SerializeField]
    InputActionReference shoot;

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBreaking = 0.1f;
    // Update is called once per frame
    void Update()
    {
        if (rawMove.magnitude < rawMoveThresholdForBreaking)
        {
            currentVelocity *= brakingCoefficient * Time.deltaTime;
        }

        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(currentVelocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started -= OnShoot;
    }

    Vector2 rawMove;

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Instantiate(projectileFab, transform.position, Quaternion.identity);
    }
}
