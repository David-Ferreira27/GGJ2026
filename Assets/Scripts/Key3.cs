using UnityEngine;

public class Key3 : MonoBehaviour, Possessable
{
    // bool is_near_door2 = false;
    // public GameObject door2;

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
        /*
        if (is_near_door2)
        {
            door2.SetActive(false);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.GetComponent<Door2>() != null){is_near_door2 = true;}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // if(collision.GetComponent<Door2>() != null){is_near_door2 = false;}
    }
}
