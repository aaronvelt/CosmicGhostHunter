using UnityEngine;

// old class refactored to enemy.cs
public class Ghost : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;

    public TextMesh ghostHealthDisplay;
    public GameObject deathEffect;
    public AudioClip deathSound;

    void Update()
    {
        ShowHealthDisplay();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        GetComponent<GhostBehaviour>().state = GhostBehaviour.stateEnum.Attack;

        ghostHealthDisplay.text = health + "/" + maxHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject deathGO = Instantiate(deathEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(deathGO, 0.5f);

        Destroy(gameObject);
    }

    void ShowHealthDisplay()
    {
        ghostHealthDisplay.transform.LookAt(2 * ghostHealthDisplay.transform.position - Camera.main.transform.position);

        if (health <= (maxHealth / 2) && health > (maxHealth / 3))
        {
            ghostHealthDisplay.color = Color.yellow;
        }
        if (health <= (maxHealth / 3))
        {
            ghostHealthDisplay.color = Color.red;
        }
    }
}
