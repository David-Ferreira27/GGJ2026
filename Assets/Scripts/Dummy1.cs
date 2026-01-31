using UnityEngine;

public class Dummy1 : MonoBehaviour
{

	private Vector2 cur_speed = new Vector2(0, 0);
	private float max_speed = 5.0f;
	private float input_force = 15.0f;
	private float friction = 8.0f;

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
	}

	private void Move()
	{
		cur_speed = rb.linearVelocity;

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


		rb.linearVelocity = cur_speed;
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
