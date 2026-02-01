using UnityEngine;

public class WaterPipe : MonoBehaviour, Possessable
{
    public GameObject water;
    public GameObject monster;
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

    public void ReleaseWater()
    {
        if (!water.activeSelf)
        {
            water.SetActive(true); 
            monster.GetComponent<Monster>().aggro = true;
            monster.GetComponent<Monster>().lastSeen = water.transform.position;
        }
    }
}
