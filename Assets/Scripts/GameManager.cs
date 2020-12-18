using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    // save current buildIndex
    public void SaveGame()
    {
        SaveData.current.buildIndex = SceneManager.GetActiveScene().buildIndex;

        SaveSystem.Save(SaveData.current);
    }

    // load saved BuildIndex
    public void LoadGame()
    {
        PlayerResources playerResc = FindObjectOfType<PlayerResources>();

        SaveData.current = (SaveData)SaveSystem.Load();

        SceneManager.LoadScene(SaveData.current.buildIndex);
    }
}
