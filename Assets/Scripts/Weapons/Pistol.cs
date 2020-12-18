using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float ammoDrain = 1f;

    public Camera fpsCam;
    public PlayerResources playerResc;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource pistolSound;

    // drain ammo on shoot and disable fire when ammo is depleted
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerResc.playerAmmo > 0)
        {
            Shoot();
            playerResc.playerAmmo -= ammoDrain;

            muzzleFlash.Play();
            pistolSound.Play();
        }
    }

    // shoot raycast forward from camera and damage if object has Enemy component
    public void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.5f);
        }
    }
}
