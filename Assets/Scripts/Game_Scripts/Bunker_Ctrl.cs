using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunker_Ctrl : MonoBehaviour
{
    private SpriteRenderer live_bunker;
    public bool level_1, level_2, level_3;
    public int lives;
    public int[] level_lives;
    public float range_live;
    private int max_lives;

    void Start()
    {
        live_bunker = this.gameObject.GetComponent<SpriteRenderer>();
        Bunker_reset();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser_Enemy" || other.gameObject.layer == LayerMask.NameToLayer("Invader")|| other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Bunker_Damage();
        }

    }

    public void Bunker_Damage()
    {
        lives--;
        range_live = 1.0f / ((float)lives);
        range_live =1.0f-range_live;
        live_bunker.color = new Color(255, 255, 255, range_live);
        if (lives <= 0)
        {
            live_bunker.color = new Color(255, 255, 255, 0.0f);
            Destroy(this.gameObject);
        }
    }

    public void Bunker_reset()
    {
        if (level_1 == true)
        {
            max_lives = level_lives[0];
        }
        if (level_2 == true)
        {
            max_lives = level_lives[1];
        }
        if (level_3 == true)
        {
            max_lives = level_lives[2];
        }

        lives = max_lives;
        range_live = 1.0f / ((float)lives);
        live_bunker.color = new Color(255, 255, 255, 1.0f);
    }
}
