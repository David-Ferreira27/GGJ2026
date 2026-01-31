using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject shards;
    private bool broken = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakWindow()
    {
        broken = true;
        shards.SetActive(true);
        gameObject.SetActive(false);
    }
}
