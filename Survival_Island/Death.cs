using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

//Dispaly Game Ovet text when  player's helath is less than 0
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
        wiad.text = "Game Over";

        yield return new WaitForSeconds(2);

        wiad.enabled = false;
    }*/
}
