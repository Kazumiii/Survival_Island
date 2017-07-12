using UnityEngine;
using System.Collections;

public class Mikstura : MonoBehaviour
{
//use potion to recover  player's health

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Zdrowie>().SendMessage("Leczenie_Mikstura", 50);
            Destroy(gameObject);
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
