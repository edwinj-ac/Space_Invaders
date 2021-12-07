using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Invader : MonoBehaviour
{
    private UI_Manager _uiManager;
    public float _FireRate;
    private float _CanFire = 0.0f;
    public ProjectTile laserPrefab;
    public bool red = false, blue = false, green = false, fire_flag=false;
    public int point = 0;
    private Invaders_Grid _invaders_Grid;

    void Start()
    {
        _uiManager = GameObject.Find("_UI_Manager").GetComponent<UI_Manager>();
        _invaders_Grid = GetComponentInParent<Invaders_Grid>();
        if (red == true)
        {
            point = 3;
        }
        if (blue == true)
        {
            point = 2;
        }
        if (green == true)
        {
            point = 1;
        }

        _FireRate = (float)Random.Range((_invaders_Grid.rate-20), _invaders_Grid.rate);
        _FireRate = _FireRate / 10;
        _CanFire = Time.time + _FireRate;
    }

    private void Update()
    {
        /*if (fire_flag == false)
        {
            StartCoroutine(begin_Shoot());
            return;
        }*/
        Shoot_Enemy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser_Enemy")
        {
            return;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Laser")){
            
            
            _uiManager.UpdateScore(point);
            _invaders_Grid.total_invaders--;
            Destroy(this.gameObject);
        }
    }

    private void Shoot_Enemy()
    {
        if (Time.time > _CanFire)
        {
            Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            _CanFire = Time.time + _FireRate;
        }

    }

    private IEnumerator begin_Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        fire_flag = true;
    }
}
