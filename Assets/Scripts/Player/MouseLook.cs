﻿using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    private float angleX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        angleX -= mouseY;
        angleX = Mathf.Clamp(angleX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(angleX, 0f, 0f);
        playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}
