using System.Collections.Specialized;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Vector2 newpos;
    public GameObject cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.transform.position = new Vector3(newpos.x, newpos.y, cam.transform.position.z);
        }
    }
}
