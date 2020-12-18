using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float AmmoValue = 50f;
    public float AmmoLimit = 750f;

    public AudioClip ammoSound;
    public Transform ammoModel;

    // When ammo is picked up increase player ammo and destroy object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float newAmmo = FindObjectOfType<PlayerResources>().playerAmmo;

            if (newAmmo != AmmoLimit)
            {
                newAmmo += AmmoValue;

                if (newAmmo >= AmmoLimit)
                {
                    newAmmo = AmmoLimit;
                }

                FindObjectOfType<PlayerResources>().playerAmmo = newAmmo;
                AudioSource.PlayClipAtPoint(ammoSound, transform.position);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        ammoModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
