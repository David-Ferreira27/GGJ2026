using UnityEngine;

public class RotatingStatue : MonoBehaviour, Possessable
{

    private int rotation_value = -90;
    private Rigidbody2D rb;

    public int times_to_rotate;
    public GameObject corresponding_middle_statue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        rb.freezeRotation = false;
        rb.transform.Rotate(0, 0, rotation_value);
        times_to_rotate--;
        if (times_to_rotate == -4) times_to_rotate = 0;
        rb.freezeRotation = true;

        if (times_to_rotate == 0)
        {
            corresponding_middle_statue.GetComponent<MiddleStatuePart>().Activate();
        }
        else if (times_to_rotate == -1)
        {
            corresponding_middle_statue.GetComponent<MiddleStatuePart>().Deactivate();
        }
    }
}
