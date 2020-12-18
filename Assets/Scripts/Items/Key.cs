using UnityEngine;

public class Key : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public SlidingDoor door;

    // set playerHasKey status to true of corresponding door
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.playerHasKey = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}