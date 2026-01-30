using System;
using UnityEngine;

public class Monster : MonoBehaviour
{

	private Vector2 cur_speed = new Vector2(0f, 0f);
	public float max_speed = 5.0f;
	private Rigidbody2D rb;
	private float angl = 90f;
	public GameObject player;
	public bool aggro = false;
	public LayerMask playerMask;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//Move();
		Rotate();
		Look();
	}

	private void Look()
	{
		bool newaggro = false;
		float rad = angl * Mathf.Deg2Rad;
		float nrays = 9f;
		float rayangl = 4f;
		for (float i = 0f; i < nrays; i++)
		{
			float temprad = (angl + rayangl * (i - nrays / 2f)) * Mathf.Deg2Rad;
			Vector2 d = new Vector2((float)Mathf.Cos(temprad), (float)Mathf.Sin(temprad));
			d.Normalize();
			RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, d, 999f, playerMask);
			newaggro = ray.collider != null | newaggro;
		}
		//RaycastHit2D ray1 = Physics2D.Raycast(gameObject.transform.position, d, 999f, playerMask);

		aggro = newaggro;
	}

	private void Rotate()
	{

		if (aggro)
		{
			Vector2 d = player.transform.position - transform.position;
			d.Normalize();
			angl = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;


		}

		transform.rotation = Quaternion.Euler(0f, 0f, angl-90f);
		//angl -= 0.1f;
	}

	private void Move()
	{
		cur_speed = new Vector2(cur_speed.x, cur_speed.y - 0.1f);

		rb.linearVelocity = cur_speed;

	}

	
}