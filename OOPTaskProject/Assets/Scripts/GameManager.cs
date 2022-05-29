using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOPTaskOne;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private HealthBarScript healthBar;

    private List<CharacterController> _enemyControllers = new List<CharacterController>();
    private List<GameObject> _missiles = new List<GameObject>();

    [SerializeField] private GameObject _stone, _bullet, _rocket;

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

    
}
