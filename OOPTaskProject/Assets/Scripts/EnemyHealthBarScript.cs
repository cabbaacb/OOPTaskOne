using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarScript : MonoBehaviour
{
    public Image healthBarImage;
    public EnemyData enemy;
    public void UpdateEnemyHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(enemy.health / enemy.maxHealth, 0, 1f);
    }
}
