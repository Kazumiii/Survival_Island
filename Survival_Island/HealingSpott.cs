using UnityEngine;
using System.Collections;

public class SpotLeczniczy : MonoBehaviour
{

//Detection collison between player and healthSpot, if payer is inside healthSpoty  player will get more health
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
