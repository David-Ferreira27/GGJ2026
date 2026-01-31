using System;
using System.Collections.Generic;
using UnityEngine;

public class MetalHammer : MonoBehaviour, Possessable
{

    bool is_near_water_pipe = false;
    
    public List<GameObject> water_pipe;

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
        if (is_near_water_pipe)
        {
            foreach(GameObject wp in water_pipe)
            {
                wp.GetComponent<WaterPipe>().ReleaseWater();   
            }
        } else if (is_near_window)
        {
            window.GetComponent<Window>().BreakWindow();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<WaterPipe>() != null){is_near_water_pipe = true;}
		if (collision.name == "Window") { is_near_window = true; }
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<WaterPipe>() != null){is_near_water_pipe = false;}
		if (collision.name == "Window") { is_near_window = true; }
	}
}
