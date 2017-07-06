using UnityEngine;
using System.Collections;

public class SpotLeczniczy : MonoBehaviour
{


    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Zdrowie>().SendMessage("Leczenie", 1);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
