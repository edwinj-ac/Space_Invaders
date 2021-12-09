using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float[] levels_speed;
    public ProjectTile laserPrefab;
    [SerializeField]
    public double _FireRate = 0.25f;
    private double _CanFire = 0.0f;
    public Invaders_Grid _invaders_grid;
    public int lives = 3;
    private UI_Manager _uiManager;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    void Start()
    {
        _invaders_grid = GameObject.Find("Invaders_Manager").GetComponent<Invaders_Grid>();
        _uiManager = GameObject.Find("_UI_Manager").GetComponent<UI_Manager>();
        Configuration_Player();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > _CanFire)
        {
            Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            _CanFire = Time.time + _FireRate;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser_Enemy" || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            Damage();
        }
        
    }
    private void Configuration_Player()
    {
        if (_invaders_grid.level_1 == true)
        {
            speed = levels_speed[0];

        }
        if (_invaders_grid.level_2 == true)
        {
            speed = levels_speed[1];
            _FireRate = _FireRate / 1.2;
        }
        if (_invaders_grid.level_3 == true)
        {
            speed = levels_speed[2];
            _FireRate = _FireRate / 1.6;
        }
    }

    public void Damage()
    {
        lives--;
        _uiManager.UpdateLives(lives);
        if (lives <= 0)
        {
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateStars(false);
            Destroy(this.gameObject);
        }
    }

}
