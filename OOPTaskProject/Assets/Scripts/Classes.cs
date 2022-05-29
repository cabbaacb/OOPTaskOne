using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//здоровье
//изменение здоровья
//стрелять пульками (параметр - тип пули)

public class Unit : MonoBehaviour
{

    public int health;

    public Missile Missile;

    [SerializeField] public float attackSpeed;
    public float timer;
    [SerializeField] public float attackRadius;
    [SerializeField] protected float movementSpeed;
    public GameObject FirePoint;
}


public enum EnemyType : byte
{
    SeasonedWolf,
    RocketCarrier,
    Gunner
}

public enum Missile : byte
{
    Stone,
    Rocket,
    Bullet
}
