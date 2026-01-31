using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Skeleton : MonoBehaviour, Possessable
{

    public List<GameObject> bones;
    public float var = 1.0f;
    bool dropped = false;

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
        if (!dropped)
        {
            float counter = -1.0f;
            foreach(GameObject b in bones)
            {
                b.SetActive(true);
                b.transform.position = new Vector3(gameObject.transform.position.x + counter, gameObject.transform.position.y - 1, 0);
                counter += 1.0f;
            }
            dropped = true;
        }
    }
}