using UnityEngine;

public class Key2 : MonoBehaviour, Possessable
{
	bool is_near_door = false;
	public GameObject door;

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
		if (is_near_door)
		{
			door.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Door_Left") { is_near_door = true; }
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Door_Left") { is_near_door = false; }
	}
}
