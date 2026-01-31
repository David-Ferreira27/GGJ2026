using UnityEngine;

public class Chair : MonoBehaviour, Possessable
{
	bool is_near_window = false;
	public GameObject window;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Interact()
	{
		if (is_near_window)
		{
			window.GetComponent<Window>().BreakWindow();
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Window") { is_near_window = true; }
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Window") { is_near_window = false; }
	}
}
