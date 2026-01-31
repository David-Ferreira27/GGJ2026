using UnityEngine;

public class MiddleStatuePart : MonoBehaviour
{

    public GameObject statue_base;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {

        transform.Find("Light").GetComponent<SpriteRenderer>().enabled = true;
        statue_base.GetComponent<MiddleStatueBase>().PartActived();
    }

    public void Deactivate()
    {

        transform.Find("Light").GetComponent<SpriteRenderer>().enabled = false;
        statue_base.GetComponent<MiddleStatueBase>().PartDeactived();
    }
}
