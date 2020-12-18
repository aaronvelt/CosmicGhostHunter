using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public TextMesh healthDisplay;
    public GameObject deathEffect;
    public AudioClip deathSound;

    private void Start()
    {
        healthDisplay.text = health + "/" + maxHealth;
    }

    // kill enemy and play death effects
    public virtual void Die()
    {
        GameObject deathGO = Instantiate(deathEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(deathGO, 0.5f);

        Destroy(gameObject);
    }

    // decrease Enemy health by the given amount
    public virtual void TakeDamage(float amount)
    {
        health -= amount;

        damageReaction();

        healthDisplay.text = health + "/" + maxHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    // give visual feedback of enemy health by displaying its value. Change color when health is lowered to a certain amount.
    public virtual void ShowHealthDisplay()
    {
        healthDisplay.transform.LookAt(2 * healthDisplay.transform.position - Camera.main.transform.position);

        if (health <= (maxHealth / 2) && health > (maxHealth / 3))
        {
            healthDisplay.color = Color.yellow;
        }
        if (health <= (maxHealth / 3))
        {
            healthDisplay.color = Color.red;
        }
    }

    // behaviour of enemy when damaged
    public abstract void damageReaction();
}
