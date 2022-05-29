using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{    
    [SerializeField] private float _rotationSpeed = 50;
    [SerializeField] private float _mouseSensitivityHorizontal = 2;


    [SerializeField] private GameManager gameManager;

    private CharacterController _controller;

    public float MouseSensitivityHorizontal
    {
        get { return _mouseSensitivityHorizontal; }
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

    }

    public void Movement(Vector3 move)
    {
        move = transform.TransformDirection(move); //this is needed to make character move considering his rotation
        _controller.Move(move * Time.deltaTime * movementSpeed);
    }

    public void Rotation(float direction)
    {
        Vector3 rotation = Vector3.zero;
        rotation.y += _rotationSpeed * direction * Time.deltaTime;
        gameObject.transform.eulerAngles += rotation;
    }

    public void Fire()
    {
        gameManager.Shooting(FirePoint, Missile);        
    }
}
