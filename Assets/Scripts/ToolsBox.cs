using UnityEngine;

public class ToolsBox : MonoBehaviour, Possessable
{

    public GameObject metal_hammer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReleaseMetalHammer()
    {
        if (!metal_hammer.activeSelf)
        {
            metal_hammer.SetActive(true);
            metal_hammer.transform.position = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, 0);   
        }
    }

    public void Interact()
    {
        
    }
}
