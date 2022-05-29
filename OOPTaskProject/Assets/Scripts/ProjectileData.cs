using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileData : MonoBehaviour
{
    //содержит информацию для настройки компонента снаряда
    //и содержит следующую информацию: тип снаряда, урон, скорость перемещения и время жизни снарядов
    public Missile Missile;

    [Range(10f, 100f)] public int damage;
    [Range(10f, 100f)] public float movementSpeed;
    [Range(0.5f, 20f)] public float remainingTime;
}
