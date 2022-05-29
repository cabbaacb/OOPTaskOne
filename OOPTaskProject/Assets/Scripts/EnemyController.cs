using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyData _enemyData;

    private void Awake()
    {
        _enemyData = gameObject.GetComponent<EnemyData>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            int damage = collision.gameObject.GetComponent<ProjectileData>().damage;
            _enemyData.health -= damage;
            collision.gameObject.GetComponent<ProjectileData>().remainingTime = 0;
        }
    }
}
