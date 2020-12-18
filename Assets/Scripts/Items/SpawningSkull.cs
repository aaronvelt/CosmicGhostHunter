using UnityEngine;

public class SpawningSkull : MonoBehaviour
{
    public float rotationSpeed = 30f;

    public Transform skullModel;
    public Transform[] spawnPoints;
    public GameObject necromancer;

    void Update()
    {
        skullModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // when player collides with object instantiate necromancer on all spawnpoints.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject enemyToSpawn = necromancer;
                enemyToSpawn.GetComponent<Necromancer>().state = Necromancer.stateEnum.Summoning;
                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
                Destroy(gameObject);
            }
        }
    }
}
