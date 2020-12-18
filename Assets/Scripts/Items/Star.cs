using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public float rotationSpeed = 30f;

    public Transform starModel;
    public Text ghostCountDisplay;

    // display ammount of enemys still alive in the level
    void Update()
    {
        ghostCountDisplay.text = "Ghosts Sighted: " + GameObject.FindGameObjectsWithTag("Enemy").Length.ToString("0");

        starModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // when player is collides with object start next level. Show warning when ghosts are still alive
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("Level Complete");
            }
            else
            {
                FindObjectOfType<WarningManager>().showStarWarning();
            }
        }
    }
}
