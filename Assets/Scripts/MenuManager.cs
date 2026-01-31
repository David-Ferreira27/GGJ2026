using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject start_menu;
    public GameObject pause_menu;
    public GameObject end_menu;

    public GameObject player;
    private Player player_script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_script = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (player_script.game_running)
            {
                if (! player_script.game_paused) PauseGame();
                else UnpauseGame();
            }
        }
    }

    public void StartGame()
    {
        player_script.game_running = true;
        start_menu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player_script.game_paused = true;
        pause_menu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        player_script.game_paused = false;
        pause_menu.SetActive(false);
    }

    public void EndGame()
    {
        player_script.game_running = false;
        end_menu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
