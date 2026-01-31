using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 cur_speed = new Vector2(0, 0);
    private float max_speed = 5.0f;
    private float input_force = 15.0f;
    private float friction = 8.0f;

    private bool not_again = false;

    private GameObject possessed_object;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyUp("space"))
        {
            not_again = false;
        }
    }

    private void Move()
    {

        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        cur_speed.x += horizontal_input * input_force * Time.deltaTime;
        cur_speed.y += vertical_input * input_force * Time.deltaTime;

        if (horizontal_input == 0)
        {
            if (cur_speed.x > 0) cur_speed.x -= friction * Time.deltaTime;
            else cur_speed.x += friction * Time.deltaTime;
        }

        if (vertical_input == 0)
        {
            if (cur_speed.y > 0) cur_speed.y -= friction * Time.deltaTime;
            else cur_speed.y += friction * Time.deltaTime;
        }

        if (cur_speed.x > max_speed) cur_speed.x = max_speed;
        if (cur_speed.x < -max_speed) cur_speed.x = -max_speed;
        if (cur_speed.y > max_speed) cur_speed.y = max_speed;
        if (cur_speed.y < -max_speed) cur_speed.y = -max_speed;

        if(possessed_object != null)
        {
            Rigidbody2D possessed_object_rb = possessed_object.GetComponent<Rigidbody2D>();
            possessed_object_rb.linearVelocity = cur_speed;
            rb.position = possessed_object_rb.position;
        }
        else
        {
            rb.linearVelocity = cur_speed;
        }
            

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("possessable") && Input.GetKey("space") && ! not_again)
        {
            not_again = true;

            if (possessed_object == null)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                possessed_object = collision.gameObject;
                rb.transform.position = new Vector3(possessed_object.transform.position.x , possessed_object.transform.position.y, 1);
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                rb.transform.position = new Vector3(possessed_object.transform.position.x, possessed_object.transform.position.y - 1, -1);
                Rigidbody2D possessed_object_rb = possessed_object.GetComponent<Rigidbody2D>();
                possessed_object_rb.linearVelocity = new Vector2(0, 0);
                possessed_object_rb.angularVelocity = 0;
                possessed_object = null;
            }

            cur_speed = new Vector2(0, 0);
        }
    }
}
