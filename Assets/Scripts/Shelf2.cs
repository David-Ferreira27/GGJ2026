using UnityEngine;

public class Shelf2 : MonoBehaviour, Possessable
{

    public GameObject museum_staff_card;
    public bool interactable = false;
    public float var = 1.0f;

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
        if (interactable && !museum_staff_card.activeSelf)
        {
            museum_staff_card.SetActive(true);
        }
    }
}
