using UnityEngine;
using System.Collections;

public class Lampa : MonoBehaviour
{
//turn light on when player is inside house 
    public Light lampa;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            lampa.enabled = true;

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            lampa.enabled = false;

        }
    }
}
