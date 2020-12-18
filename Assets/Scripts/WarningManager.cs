using UnityEngine;
using UnityEngine.UI;

// display warnings class
public class WarningManager : MonoBehaviour
{
    public float warningTime = 2f;
    private float disapearWarningTime;

    public Text starWarning;
    public Text keyWarning;
    public Text saveNotice;

    void Start()
    {
        starWarning.enabled = false;
        keyWarning.enabled = false;
        saveNotice.enabled = false;
    }

    private void Update()
    {
        if (Time.time >= disapearWarningTime)
        {
            starWarning.enabled = false;
            keyWarning.enabled = false;
            saveNotice.enabled = false;
        }
    }

    public void showStarWarning()
    {
        starWarning.enabled = true;
        disapearWarningTime = Time.time + warningTime;
    }

    public void showKeyWarning()
    {
        keyWarning.enabled = true;
        disapearWarningTime = Time.time + warningTime;
    }

    public void showSaveNotice()
    {
        saveNotice.enabled = true;
        disapearWarningTime = Time.time + warningTime;
    }
}
