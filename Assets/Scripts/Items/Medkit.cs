using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float medKitValue = 25f;

    public AudioClip medkitSound;
    public Transform medkitModel;

    // when medKit is picked up increase player health and delete object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float playerHealth = FindObjectOfType<PlayerResources>().playerHealth;

            if (playerHealth != 100f)
            {
                playerHealth += medKitValue;

                if (playerHealth >= 100f)
                {
                    playerHealth = 100f;
                }

                FindObjectOfType<PlayerResources>().playerHealth = playerHealth;
                AudioSource.PlayClipAtPoint(medkitSound, transform.position);
                Destroy(gameObject);
            }
        }   
    }

    void Update()
    {
        // keep the medkit rotating at all times
        medkitModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
