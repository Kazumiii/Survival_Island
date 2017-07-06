using UnityEngine;
using System.Collections;

public class Drzwi : MonoBehaviour
{

    public AudioClip OpenDoor;
    public AudioClip CloseDoor;

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(OpenDoor, transform.position);
            animation.Play("dooropen");

            yield return new WaitForSeconds(2);

            animation.Play("doorshut");
            AudioSource.PlayClipAtPoint(CloseDoor, transform.position);

        }
    }
}
