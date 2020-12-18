using UnityEngine;

public class GhostOrb : MonoBehaviour
{
    public float orbDamage = 20f;
    public float orbSpeed = 20f;
    public float orbRange = 100f;
    public Vector3 playerPos;

    public GameObject explosionEffect;
    public AudioClip explosionSound;
    private Quaternion rotation;
    private Vector3 startPos;
    PlayerResources playerResc;

    // set ghost orbs destination to the players position
    void Start()
    {
        playerResc = FindObjectOfType<PlayerResources>();
        startPos = transform.position;

        Vector3 relativePos = playerPos - transform.position;
        rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    }

    // increase ghost orb position until orbRange is reached.
    void Update()
    {
        if (playerPos != null)
        {
            transform.rotation = rotation;
            transform.position += transform.forward * Time.deltaTime * orbSpeed;
        }

        float dist = Vector3.Distance(startPos, transform.position);

        if (dist >= orbRange)
        {
            Destroy(gameObject);
        }

    }

    // When ghostOrb collides with player: damage player health. Destroy on collision with player tag or default layer
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0 || other.tag == "Player")
        {
            Debug.Log("Collisoin Deteced");

            GameObject explosionGO = Instantiate(explosionEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

            if (other.tag == "Player")
            {
                playerResc.playerHealth -= orbDamage;
            }

            Destroy(explosionGO, 0.5f);

            Destroy(gameObject);
        }
    }
}
