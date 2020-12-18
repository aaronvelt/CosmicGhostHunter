using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public Transform saveModel;

    void Update()
    {
        saveModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // save current level on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().SaveGame();
            FindObjectOfType<WarningManager>().showSaveNotice();
            Destroy(gameObject);
        }
    }

}
