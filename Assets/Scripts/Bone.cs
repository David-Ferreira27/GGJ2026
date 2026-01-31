using UnityEngine;

public class Bone : MonoBehaviour, Possessable
{
    bool is_near_chicken = false;
    public GameObject chicken;
    public int i;

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
        if (is_near_chicken)
        {
            chicken.GetComponent<Chicken>().AttachBone(i);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Chicken>() != null){is_near_chicken = true;}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Chicken>() != null){is_near_chicken = false;}
    }
}
