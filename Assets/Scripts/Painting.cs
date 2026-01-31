using UnityEngine;

public class Painting : MonoBehaviour, Possessable
{
    public GameObject key;
    private bool used = false;
    public GameObject sprite2;
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
        if (!key.activeSelf && !used)
        {
            key.SetActive(true);
			key.transform.position = new Vector3(gameObject.transform.position.x -0.2f, gameObject.transform.position.y - 0.5f, 0f);
            used = true;
            sprite2.SetActive(true);
            transform.position = sprite2.transform.position;
			gameObject.SetActive(false);
		}
	}
}
