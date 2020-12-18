using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerResources : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerAmmo = 500f;
    public Text healthDisplay;
    public Text ammoDisplay;

    // display players current health and ammo. call game over when health is depleted
    void Update()
    {
        healthDisplay.text = "Health: " + playerHealth.ToString("0");
        ammoDisplay.text = "Ammo: " + playerAmmo.ToString("0");

        if (playerHealth <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
