using UnityEngine;

public class CardboardBox : MonoBehaviour, Possessable
{

    public GameObject tools_box;
    public float var = 1.0f;

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
        if (!tools_box.activeSelf)
        {
            tools_box.SetActive(true);
            tools_box.transform.position = new Vector3 (gameObject.transform.position.x - 1, gameObject.transform.position.y, 0);
        }
    }

    
}
