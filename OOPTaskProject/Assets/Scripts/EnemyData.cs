using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOPTaskOne;
public class EnemyData : Unit
{
    [SerializeField] private GameManager gameManager;

    // информацию для настройки компонента противников и содержит следующую информацию:
    // тип противника, здоровье, тип используемого снаряда, скорость атаки, дальность атаки и скорость перемещения;
    public EnemyType Type;

    private void EnemyTargeting()
    {
        var player = GetComponent<PlayerController>();
        var distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= attackRadius)
            transform.LookAt(player.transform);
    }



}
