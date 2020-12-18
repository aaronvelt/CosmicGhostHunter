using UnityEngine;

public class RotateSpace : MonoBehaviour
{
    public float rotatingSpeed = 1.2f;

    //rotate skybox
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotatingSpeed);
    }
}
