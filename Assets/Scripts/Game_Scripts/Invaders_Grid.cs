using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_Grid : MonoBehaviour
{

    public GameObject[] prefabs_invaders;
    public int rows, columns, total_invaders, range1, range2, range3, rate;
    public int[] level_col;
    public bool level_1, level_2, level_3;
    public float speed, advance_invaders_y;
    public float[] level_Speed, level_advance_y;
    private Vector3 _direction = Vector2.right;
   

    private void Awake()
    {
        Begin_Restar_Invaders();
        total_invaders = (rows-1) * columns;
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if(!invader.gameObject.activeInHierarchy)
            {
                continue;
            }  
            
            if(_direction == Vector3.right && invader.position.x >= rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }else if(_direction == Vector3.left && invader.position.x <= leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
        }

        if(total_invaders <= 0)
        {
            Debug.Log("WIN");
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= advance_invaders_y;
        this.transform.position = position;
    }

    public void Begin_Restar_Invaders()
    {
        if (level_1 == true)
        {
            rate = range1;
            advance_invaders_y = level_advance_y[0];
            speed = level_Speed[0];
            columns = level_col[0];
        }
        if (level_2 == true)
        {
            rate = range1;
            advance_invaders_y = level_advance_y[1];
            speed = level_Speed[1];
            columns = level_col[1];
        }
        if (level_3 == true)
        {
            rate = range1;
            advance_invaders_y = level_advance_y[2];
            speed = level_Speed[2];
            columns = level_col[2];
        }

        for (int row = 0; row < this.rows - 1; row++)
        {
            float width = 1.5f * (this.columns - 1);
            float height = 1.5f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 1.5f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                GameObject invader = Instantiate(this.prefabs_invaders[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 1.5f;
                invader.transform.localPosition = position;
            }
        }
    }


}
