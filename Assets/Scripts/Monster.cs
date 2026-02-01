using System;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{

	private Vector2 cur_speed = new Vector2(0f, 0f);
	public float max_speed = 0.1f;
	private Rigidbody2D rb;
	private float angl = 90f;
	private float rad;
	public GameObject player;
	public bool aggro = false;

	private Vector3 lastSeen;
	public float rotateTimer = -1f;
	public Vector3 lastPathPos;
    public GameObject menuObject;
    private MenuManager menu_manager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
        Physics2D.queriesHitTriggers = false;
		rb = GetComponent<Rigidbody2D>();
		rad = angl * Mathf.Deg2Rad;
		menu_manager = menuObject.GetComponent<MenuManager>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if(player.GetComponent<Player>().game_running && !player.GetComponent<Player>().game_paused)
        {
            rad = angl * Mathf.Deg2Rad;

            Move();
            Rotate();
            Look();
        }
	}

	private void Look()
	{
		bool newaggro = false;
		float nrays = 30f;
		float rayangl = 3f;
		float offset = 0.15f;
		RaycastHit2D ray;
        for (float i = 0f; i < nrays; i++)
        {
            float rayrad = (angl + rayangl * (i - nrays / 2f)) * Mathf.Deg2Rad;
            Vector2 d = new Vector2((float)Mathf.Cos(rayrad), (float)Mathf.Sin(rayrad));
            d.Normalize();
            ray = Physics2D.Raycast(gameObject.transform.position + new Vector3((float)Mathf.Cos(rad) * offset, (float)Mathf.Sin(rad) * offset, 0f), d, 999f);
            if (ray.collider != null && ray.collider.gameObject.tag == "Player")
            {
                newaggro = true;
            }

        }

        if (!aggro && newaggro) menu_manager.ActivateAggro();
        if (aggro && !newaggro) menu_manager.DeactivateAggro();

        aggro = newaggro;

		if (aggro)
		{
			rotateTimer = 5f;
			lastSeen = player.transform.position;
		}
	}

	private void Rotate()
	{
		if(rb.linearVelocity == new Vector2(0, 0) && rotateTimer > 0f)
		{
			angl++;
			rotateTimer -= Time.deltaTime;
		}

		if(rotateTimer < 0f && InPath())
		{
			if(angl!=180f && angl!=0f){angl = 0f;}
			if(gameObject.transform.position.x>-16f){angl=180f;}
			if(-20f>gameObject.transform.position.x){angl = 0f;}
			lastPathPos = gameObject.transform.position;
		}
		if(rotateTimer < 0f && !InPath())
		{
			Vector2 d = lastPathPos - transform.position;
			d.Normalize();
			angl = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
		}

		if (aggro)
		{
			Vector2 d = lastSeen - transform.position;
			d.Normalize();
			angl = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
		}

		transform.rotation = Quaternion.Euler(0f, 0f, angl-90f);

		//angl -= 0.1f;
	}

	private void Move()
	{
		Vector2 speed = new Vector2(0,0);
		if(!aggro && (rotateTimer < 0f || Math.Abs(gameObject.transform.position.x - lastSeen.x) > max_speed || Math.Abs(gameObject.transform.position.y - lastSeen.y) > max_speed) || aggro){speed = new Vector2(Mathf.Cos(rad) * max_speed, Mathf.Sin(rad) * max_speed);}

		rb.linearVelocity = speed;

	}

	private bool InPath()
	{
		if(Near(gameObject.transform.position.y,0f,max_speed) && -20f-max_speed<gameObject.transform.position.x && gameObject.transform.position.x<-16f+max_speed){return true;}
		return false;
	}

	private bool Near(float myPos, float targetPos, float offset)
	{
		if(Math.Abs(myPos-targetPos) < offset){return true;}
		return false;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger) return;

        if (collision.CompareTag("Player"))
        {
            menu_manager.EndGameLose();
        }
    }


}
