using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MiddleStatueBase : MonoBehaviour
{

    private int active_statue_parts = 0;
    public bool all_active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PartActived()
    {
        active_statue_parts++;

        if (active_statue_parts == 4)
        {
            //open door
            all_active = true;
        }
    }

    public void PartDeactived()
    {
        active_statue_parts--;
    }
}
