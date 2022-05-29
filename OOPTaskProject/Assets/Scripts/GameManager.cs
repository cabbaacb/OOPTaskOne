using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private List<EnemyData> _enemies = new List<EnemyData>();
    private List<ProjectileData> _missilesData = new List<ProjectileData>();

    [SerializeField] private GameObject _stone, _bullet, _rocket;
    [SerializeField] private List<GameObject> _enemyPrefabs = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)]);
            enemy.transform.position = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
            enemy.transform.rotation = Random.rotation;
            enemy.transform.eulerAngles = new Vector3(0, enemy.transform.eulerAngles.y, 0);
            EnemyData enemyData = enemy.GetComponent<EnemyData>();
            _enemies.Add(enemyData);
        }
    }

    private void Update()
    {
        foreach (ProjectileData missile in _missilesData)
        {
            missile.remainingTime -= Time.deltaTime;
            if (missile.remainingTime <= 0)
            {
                Destroy(missile.gameObject);
            }
        }
        _missilesData.RemoveAll(missile => missile.remainingTime <= 0);

        foreach (EnemyData enemy in _enemies)
        {
            if (enemy.health <= 0)
            {
                Destroy(enemy.gameObject);
            }
            else if (Vector3.Distance(_player.transform.position, enemy.gameObject.transform.position) <= enemy.attackRadius)
            {
                Aim(enemy.gameObject, _player);
               
                if (enemy.timer <= 0)
                {
                    enemy.timer = enemy.attackSpeed;
                    Shooting(enemy.FirePoint, enemy.Missile);
                }
                else
                {
                    enemy.timer -= Time.deltaTime * 10;
                }
            }
        }
        _enemies.RemoveAll(enemy => enemy.health <= 0);
    }

    private void Aim(GameObject shooter, GameObject target)
    {
        shooter.transform.LookAt(target.transform);
    }


    public void Shooting(GameObject firePoint, Missile missile)
    {        
        GameObject _missile;

        switch (missile)
        {
            case Missile.Stone:
                _missile = Instantiate(_stone, firePoint.transform.position,firePoint.transform.rotation);
                break;
            case Missile.Rocket:
                _missile = Instantiate(_rocket, firePoint.transform.position, firePoint.transform.rotation);
                break;
            case Missile.Bullet:
                _missile = Instantiate(_bullet, firePoint.transform.position, firePoint.transform.rotation);
                break;
            default:
                _missile = Instantiate(_bullet, firePoint.transform.position, firePoint.transform.rotation);
                break;
        }

        _missile.layer = firePoint.layer;  
        Rigidbody _missileRB = _missile.AddComponent<Rigidbody>();
        _missileRB.useGravity = false;
        ProjectileData _missileData = _missile.GetComponent<ProjectileData>();
        _missileRB.AddRelativeForce(transform.up * _missileData.movementSpeed * 10f, ForceMode.Acceleration);

        _missilesData.Add(_missileData);
    }
}
