using UnityEngine;

public class Key : MonoBehaviour, Possessable
{
    bool is_near_toolbox = false;
    public GameObject tool_box;

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
        if (is_near_toolbox)
        {
            tool_box.GetComponent<ToolsBox>().ReleaseMetalHammer();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ToolsBox>() != null){is_near_toolbox = true;}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<ToolsBox>() != null){is_near_toolbox = false;}
    }
}
