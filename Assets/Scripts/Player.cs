using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 cur_speed = new Vector2(0, 0);
    public float max_speed = 5.0f;
    public float input_force = 1.0f;
    public float friction = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        cur_speed.x += horizontal_input;
        cur_speed.y += vertical_input;

        if (horizontal_input == 0 && vertical_input == 0)
        {
            if (cur_speed.x > 0) cur_speed.x -= Min(friction, cur_speed.x);
            else cur_speed.x += Min(friction, -cur_speed.x);
            if (cur_speed.y > 0) cur_speed.y -= Min(friction, cur_speed.y);
            else cur_speed.y += Min(friction, -cur_speed.y);

            transform.Translate(cur_speed);
        }
    }

    private float Min(float a, float b)
    {
        if (a < b) return a;
        return b;
    }

    private float Max(float a, float b)
    {
        if (a > b) return a;
        return b;
    }
}
