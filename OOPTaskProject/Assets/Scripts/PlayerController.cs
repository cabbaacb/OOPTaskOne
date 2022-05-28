using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _rotationSpeed = 50;
    [SerializeField] private float _mouseSensitivityHorizontal = 2;
    [SerializeField] private GameObject _firePoint;

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
        _controller.Move(move * Time.deltaTime * _speed);
    }

    public void Rotation(float direction)
    {
        Vector3 rotation = Vector3.zero;
        rotation.y += _rotationSpeed * direction * Time.deltaTime;
        gameObject.transform.eulerAngles += rotation;
    }

    public void Fire()
    {
        print("Fire");
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.layer = 8;   //I decided to put bulllets in separate layer, and disable collisions between them.
        //sphere.transform.position = _firePoint.transform.position;
        //Rigidbody sphereRB = sphere.AddComponent<Rigidbody>();
        //sphereRB.useGravity = false;
        //sphereRB.AddForce(transform.forward * 1000f);
    }
}
