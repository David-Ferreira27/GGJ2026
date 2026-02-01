using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject start_menu;
    public GameObject pause_menu;
    public GameObject end_menu_win;
    public GameObject end_menu_lose;
    public GameObject aggro_menu;


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
        Time.timeScale = 1f;
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

    public void EndGameWin()
    {
        Time.timeScale = 0f;
        player_script.game_running = false;
        aggro_menu.SetActive(false);
        end_menu_win.SetActive(true);
    }

    public void EndGameLose()
    {
        Time.timeScale = 0f;
        player_script.game_running = false;
        aggro_menu.SetActive(false);
        end_menu_lose.SetActive(true);
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

    public void ActivateAggro()
    {
        aggro_menu.SetActive(true);
    }

    public void DeactivateAggro()
    {
        aggro_menu.SetActive(false);
    }

}
