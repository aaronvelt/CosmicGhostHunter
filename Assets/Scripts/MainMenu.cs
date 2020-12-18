using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Load()
    {
        FindObjectOfType<GameManager>().LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
