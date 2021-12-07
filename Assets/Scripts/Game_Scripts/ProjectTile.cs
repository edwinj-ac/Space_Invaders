using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public bool isLaserEnemy = false;

    private void Update()
    {
        if (isLaserEnemy)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= -6)
            {
                Destroy(gameObject);

            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (transform.position.y >= 6)
            {
                Destroy(gameObject);

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLaserEnemy)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
            {
                return;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                return;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
