using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOPTaskOne;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private HealthBarScript healthBar;
    [SerializeField] private EnemyHealthBarScript enemyHealthBar;

    private List<CharacterController> _enemyControllers = new List<CharacterController>();
    private List<GameObject> _missiles = new List<GameObject>();
    private int _enemyCount = 0;

    private Coroutine _enemySpawn;

    [SerializeField] private GameObject _stone, _bullet, _rocket;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateHealthBar();
        enemyHealthBar.UpdateEnemyHealthBar();

        _enemySpawn = StartCoroutine(EnemySpawn());
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

        print(_missile);
        _missile.layer = firePoint.layer;  
        Rigidbody _missileRB = _missile.AddComponent<Rigidbody>();
        _missileRB.useGravity = false;
        _missileRB.AddRelativeForce(transform.up * _missile.GetComponent<ProjectileData>().movementSpeed * 10f, ForceMode.Acceleration);

        _missiles.Add(_missile);
    }

    private IEnumerator EnemySpawn()
    {
        if (_enemyCount <= 20)
        {
            GameObject _enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyData>().EnemyTargeting();
            _enemyControllers.Add(enemy.GetComponent<CharacterController>());
            _enemyCount++;
        }
        yield return new WaitForSeconds(5f);
        //можно добавить ещё спавн нового врага каждые 30 секунд просто прекола для.
    }
}
