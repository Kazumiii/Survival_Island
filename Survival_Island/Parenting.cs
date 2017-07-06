using UnityEngine;
using System.Collections;

public class Parentowanie : MonoBehaviour
{


    public GUIText wiad;
    bool przełącznik = false;
    // Use this for initialization


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            wiad.enabled = true;
            wiad.text = "Czy chcesz adopotwoac tego cuba? Tak-wcisnij U/ Nie-wcisnij O";
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (przełącznik)
            {

                gameObject.transform.parent = col.transform;
            }
        }
        else
            gameObject.transform.parent = null;

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            wiad.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !przełącznik)
        {
            przełącznik = true;
            wiad.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.O) & przełącznik)
        {
            przełącznik = false;
            wiad.enabled = false;
        }
    }
}
