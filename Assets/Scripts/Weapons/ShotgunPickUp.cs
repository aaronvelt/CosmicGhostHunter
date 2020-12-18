using UnityEngine;

public class ShotgunPickUp : MonoBehaviour
{
    public float rotationSpeed = 30f;

    public Transform shotgunModel;

    void Update()
    {
        shotgunModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // set playerHasShotgun to true on collision and equip shotugn
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GunManager>().playerHasShotgun = true;
        FindObjectOfType<GunManager>().SelectWeapon("Shotgun");
        Destroy(gameObject);
    }
}
