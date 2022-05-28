using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemControls : MonoBehaviour
{
    private PlayerController _player;

    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _rotationAction;

    private Coroutine _movement;
    private Coroutine _rotation;

    private void Awake()
    {
        Cursor.visible = false;
        _playerInput = GetComponent<PlayerInput>();
        _player = GetComponent<PlayerController>();
        _moveAction = _playerInput.actions["Movement"];
        _rotationAction = _playerInput.actions["Rotation"];
    }

    private void OnEnable()
    {
        _playerInput.actions["Movement"].started += MovementStart;
        _playerInput.actions["Movement"].canceled += MovementStop;
        _playerInput.actions["Rotation"].started += RotationStart;
        _playerInput.actions["Rotation"].canceled += RotationStop;
        _playerInput.actions["Fire"].performed += Fire;
    }
    private void OnDisable()
    {
        _playerInput.actions["Movement"].started -= MovementStart;
        _playerInput.actions["Movement"].canceled -= MovementStop;
        _playerInput.actions["Rotation"].started -= RotationStart;
        _playerInput.actions["Rotation"].canceled -= RotationStop;
        _playerInput.actions["Fire"].performed -= Fire;
    }

    private void Update()
    {
        if (_rotation == null)
        {
            Vector2 pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            _player.Rotation((pos.x - 0.5f) * _player.MouseSensitivityHorizontal);
        }
    }

    private void MovementStart(InputAction.CallbackContext context)
    {
        _movement = StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0f, input.y);
        _player.Movement(move);
        yield return null;
        _movement = StartCoroutine(Movement());
    }
    private void MovementStop(InputAction.CallbackContext context)
    {
        StopCoroutine(_movement);
    }

    private void RotationStart(InputAction.CallbackContext context)
    {
        _rotation = StartCoroutine(Rotation());
    }

    private IEnumerator Rotation()
    {
        float input = _rotationAction.ReadValue<float>();
        _player.Rotation(input);
        yield return null;
        _rotation = StartCoroutine(Rotation());
    }
    private void RotationStop(InputAction.CallbackContext context)
    {
        StopCoroutine(_rotation);
        _rotation = null;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        _player.Fire();
    }
}
