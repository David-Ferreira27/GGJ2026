using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject menu_object;
    private MenuManager menu_manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu_manager = menu_object.GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;

        if (collision.CompareTag("Player"))
        {
            menu_manager.EndGameWin();
        }
    }
}
