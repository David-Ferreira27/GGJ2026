using System;
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


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rad = angl * Mathf.Deg2Rad;
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		rad = angl * Mathf.Deg2Rad;

		Move();
		Rotate();
		Look();
	}

	private void Look()
	{
		bool newaggro = false;
		float nrays = 9f;
		float rayangl = 8f;
		if (!aggro)
		{
			for (float i = 0f; i < nrays; i++)
			{
				float rayrad = (angl + rayangl * (i - nrays / 2f)) * Mathf.Deg2Rad;
				Vector2 d = new Vector2((float)Mathf.Cos(rayrad), (float)Mathf.Sin(rayrad));
				d.Normalize();
				RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, d, 999f);
				if (ray.collider != null && ray.collider.gameObject.tag == "Player")
				{
					newaggro = true;
				}

			}
		}
		else
		{
			Vector2 d = new Vector2((float)Mathf.Cos(rad), (float)Mathf.Sin(rad));
			d.Normalize();
			RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, d, 999f);
			if (ray.collider != null && ray.collider.gameObject.tag == "Player")
			{
				newaggro = true;
			}
		}

		aggro = newaggro;

		if (aggro)
		{
			lastSeen = player.transform.position;
		}
	}

	private void Rotate()
	{

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
		Vector2 speed = new Vector2(Mathf.Cos(rad) * max_speed, Mathf.Sin(rad) * max_speed);

		rb.linearVelocity = speed;

	}

	
}