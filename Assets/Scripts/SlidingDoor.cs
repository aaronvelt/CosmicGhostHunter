using System.Collections;
using UnityEngine;

// Script inspired from DoubleSlidingDoorController.cs from the low poly Flat Scifi Assets Pack
public class SlidingDoor : MonoBehaviour
{
    public enum SlidingDoorStatus {Closed,Locked,Open,Animating};
    public SlidingDoorStatus status = SlidingDoorStatus.Closed;

    public Transform leftDoor;
    public Transform rightDoor;

    public float slideDistance = 1.76f;
    public float slideSpeed = 1f;
    public bool playerHasKey = false;

    private Vector3 leftDoorClosedPosition;
    private Vector3 leftDoorOpenPosition;

    private Vector3 rightDoorClosedPosition;
    private Vector3 rightDoorOpenPosition;

    private int PlayerInDoorArea = 0;

    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;


    void Start()
    {
        leftDoorClosedPosition = new Vector3(0f, 0f, 0f);
        leftDoorOpenPosition = new Vector3(-slideDistance, 0f, 0f);

        rightDoorClosedPosition = new Vector3(0f, 0f, 0f);
        rightDoorOpenPosition = new Vector3(slideDistance, 0f, 0f);
    }

    // close door if player is outside door area
    void Update()
    {
        if (status != SlidingDoorStatus.Animating)
        {
            if (status == SlidingDoorStatus.Open)
            {
                if (PlayerInDoorArea == 0)
                {
                    StartCoroutine("CloseDoors");
                }
            }
        }
    }

    // when player reaches door are check if key is needed or door is animating. Open door when checks are completed
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (status == SlidingDoorStatus.Locked && playerHasKey)
            {
                status = SlidingDoorStatus.Closed;
            }

            if (status == SlidingDoorStatus.Locked)
            {
                FindObjectOfType<WarningManager>().showKeyWarning();
            }

            // when player enters door
            if (status != SlidingDoorStatus.Animating)
            {
                if (status == SlidingDoorStatus.Closed)
                {
                    StartCoroutine("OpenDoors");
                }
            }

            if (other.GetComponent<Collider>().gameObject.tag == "Player")
            {
                PlayerInDoorArea++;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {

    }

    // decrease playerInDoorArea when player leaves door area
    void OnTriggerExit(Collider other)
    {
        //	Keep tracking of player on the door
        if (other.GetComponent<Collider>().gameObject.tag == "Player")
        {
            PlayerInDoorArea--;
        }
    }

    // play open door animation and set status to open
    IEnumerator OpenDoors()
    {
        if (openDoorSound != null)
        {
            AudioSource.PlayClipAtPoint(openDoorSound, transform.position);
        }

        status = SlidingDoorStatus.Animating;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * slideSpeed;

            leftDoor.localPosition = Vector3.Slerp(leftDoorClosedPosition, leftDoorOpenPosition, time);
            rightDoor.localPosition = Vector3.Slerp(rightDoorClosedPosition, rightDoorOpenPosition, time);

            yield return null;
        }

        status = SlidingDoorStatus.Open;
    }

    // play close door animation and set status to closed
    IEnumerator CloseDoors()
    {
        if (closeDoorSound != null)
        {
            AudioSource.PlayClipAtPoint(closeDoorSound, transform.position);
        }

        status = SlidingDoorStatus.Animating;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * slideSpeed;

            leftDoor.localPosition = Vector3.Slerp(leftDoorOpenPosition, leftDoorClosedPosition, time);
            rightDoor.localPosition = Vector3.Slerp(rightDoorOpenPosition, rightDoorClosedPosition, time);

            yield return null;
        }

        status = SlidingDoorStatus.Closed;
    }

    //	Forced door opening
    public bool DoOpenDoor()
    {

        if (status != SlidingDoorStatus.Animating)
        {
            if (status == SlidingDoorStatus.Closed)
            {
                StartCoroutine("OpenDoors");
                return true;
            }
        }

        return false;
    }

    //	Forced door closing
    public bool DoCloseDoor()
    {

        if (status != SlidingDoorStatus.Animating)
        {
            if (status == SlidingDoorStatus.Open)
            {
                StartCoroutine("CloseDoors");
                return true;
            }
        }

        return false;
    }
}
