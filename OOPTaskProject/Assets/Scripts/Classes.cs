using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPTaskOne
{
    //здоровье
    //изменение здоровья
    //стрелять пульками (параметр - тип пули)

    public class Unit : MonoBehaviour
    {

        public int health;
        
        public CharacterController Controller;
        public Missile Missile;

        [SerializeField] protected float attackSpeed;
        [SerializeField] protected float attackRadius;
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
}
