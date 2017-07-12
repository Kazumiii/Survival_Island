using UnityEngine;
using System.Collections;

public class OtwarcieBamy : MonoBehaviour
{
//Detection collison Player-gate and then  opening Gate
    public AudioClip OpenDoor;
    public AudioClip Dzwiek;
    public GameObject Drzwi;
    bool przełącznik = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            audio.PlayOneShot(OpenDoor);
            przełącznik = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            audio.Stop();
        }

    }


//load sound file during opening gate

    IEnumerator Door()
    {

        AudioSource.PlayClipAtPoint(Dzwiek, transform.position);
        animation.Play("run");

        yield return new WaitForSeconds(2);

        AudioSource.PlayClipAtPoint(Dzwiek, transform.position);
        Drzwi.animation.Play("doorshut");

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (przełącznik)
            {
                StartCoroutine("Door");
                przełącznik = false;
            }
        }
    }
}
