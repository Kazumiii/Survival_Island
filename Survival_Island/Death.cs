using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public GUIText wiad;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Gracz.zycie--;
            if (Gracz.zycie == 0)
            {

                StartCoroutine("wiadomosc");

            }
        }
    }



    IEnumerator wiadomosc()
    {
        if (!wiad.enabled)
            wiad.enabled = true;
        wiad.text = "Koniec Gry";

        yield return new WaitForSeconds(2);

        wiad.enabled = false;
    }*/
}
