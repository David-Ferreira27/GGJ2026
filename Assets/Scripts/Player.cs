using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    private Vector2 cur_speed = Vector2.zero;
    private float max_speed = 5.0f;
    private float input_force = 15.0f;
    private float friction = 3.0f;


    public List<GameObject> can_possess_objects = new List<GameObject>();
    private GameObject possessed_object = null;

    private Rigidbody2D rb;

    public LayerMask objectMask;
    public LayerMask wallMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SortObjects();

        if (Input.GetKeyDown("space"))
        {
            if (possessed_object == null && can_possess_objects.Count() > 0)
            {
                Possess();
            }
            else if (possessed_object != null)
            {
                Despossess();
            }
        }

        if (Input.GetKeyDown("p") && possessed_object != null)
        {
            Possessable possessed_script = possessed_object.GetComponent<Possessable>();
            possessed_script.Interact();
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
            if (cur_speed.x > 0)
            {
                if (cur_speed.x > friction * Time.deltaTime) cur_speed.x -= friction * Time.deltaTime;
                else cur_speed.x = 0f;
            }
            else
            {
                if (cur_speed.x < - friction * Time.deltaTime) cur_speed.x += friction * Time.deltaTime;
                else cur_speed.x = 0f;
            }
        }

        if (vertical_input == 0)
        {
            if (cur_speed.y > 0)
            {
                if (cur_speed.y > friction * Time.deltaTime) cur_speed.y -= friction * Time.deltaTime;
                else cur_speed.y = 0f;
            }
            else
            {
                if (cur_speed.y < -friction * Time.deltaTime) cur_speed.y += friction * Time.deltaTime;
                else cur_speed.y = 0f;
            }
        }

        if (cur_speed.x > max_speed) cur_speed.x = max_speed;
        if (cur_speed.x < -max_speed) cur_speed.x = -max_speed;
        if (cur_speed.y > max_speed) cur_speed.y = max_speed;
        if (cur_speed.y < -max_speed) cur_speed.y = -max_speed;

        if(possessed_object != null)
        {
            Rigidbody2D possessed_object_rb = possessed_object.GetComponent<Rigidbody2D>();
            possessed_object_rb.linearVelocity = cur_speed;
        }
        else
        {
            rb.linearVelocity = cur_speed;
        }
            

    }

    private void SortObjects()
    {
        can_possess_objects.Sort((a, b) =>
        Vector3.Distance(transform.position, a.transform.position)
        .CompareTo(Vector3.Distance(transform.position, b.transform.position))
    );
    }

    private void Possess()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        possessed_object = can_possess_objects[0];
        possessed_object.tag = "Player";
        rb.transform.position = new Vector2(-100, 0);

        rb.linearVelocity = Vector2.zero;
        cur_speed = Vector2.zero;

        can_possess_objects.Clear();

    }

    private void Despossess()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

        Rigidbody2D possessed_object_rb = possessed_object.GetComponent<Rigidbody2D>();
        DecideDirection(possessed_object_rb, 0.5f);

        rb.linearVelocity = Vector2.zero;
        cur_speed = Vector2.zero;

        possessed_object_rb.linearVelocity = Vector2.zero;
		possessed_object.tag = "possessable";
		possessed_object = null;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("possessable") && possessed_object == null)
        {

            can_possess_objects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("possessable") && possessed_object == null)
        {

            can_possess_objects.Remove(collision.gameObject);
        }
    }

    private void DecideDirection(Rigidbody2D object_rb, float startDistance)
    {
        float distance = startDistance;
        List<Vector2> directions = new List<Vector2>(){ Vector2.down, Vector2.up, Vector2.left, Vector2.right };
        bool placed = false;

        Collider2D playerCollider = GetComponent<BoxCollider2D>();

        while (!placed)
        {
            List<Vector2> toRemove = new List<Vector2>();

            foreach (Vector2 dir in directions)
            {
                Vector2 newPos = (Vector2)object_rb.position + dir * distance;


                if (CanPlaceAt(newPos, playerCollider) == "Wall")
                {
                    toRemove.Add(dir);
                    
                }

                if (CanPlaceAt(newPos, playerCollider) == "Free")
                {
                    rb.transform.position = newPos;
                    placed = true;
                    break;
                }
            }

            foreach (Vector2 dir in toRemove)
            {
                directions.Remove(dir);
            }

            distance += 0.1f;

            if (distance > 10f)
            {
                Debug.LogWarning("DecideDirection: no free space found for player!");
                break;
            }
        }
    }

    private string CanPlaceAt(Vector2 position, Collider2D colliderToCheck)
    {
        
        Collider2D hitWall = Physics2D.OverlapBox(position, colliderToCheck.bounds.size, 0f, wallMask);
        if (hitWall != null) return "Wall";

        Collider2D hitObject = Physics2D.OverlapBox(position, colliderToCheck.bounds.size, 0f, objectMask);
        if (hitObject != null) return "Object";

        else return "Free";

    }

}
