using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MiddleStatueBase : MonoBehaviour, Possessable
{

    private int active_statue_parts = 0;
    public bool all_active = false;
    public GameObject shelf2;

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
        
    }

    public void PartActived()
    {
        active_statue_parts++;

        if (active_statue_parts == 4)
        {
            all_active = true;
            shelf2.GetComponent<Shelf2>().interactable = true;
        }
    }

    public void PartDeactived()
    {
        active_statue_parts--;
    }
}
