using UnityEngine;

public class Dummy1 : MonoBehaviour
{
	public float speed = 2f;
	public float moveTime = 2f;

	private Rigidbody2D rb;
	private float timer;
	private int direction = 1;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		timer += Time.fixedDeltaTime;

		if (timer >= moveTime)
		{
			timer = 0f;
			direction *= -1;
		}

		rb.linearVelocity = new Vector2(speed * direction, 0f);
	}
}
