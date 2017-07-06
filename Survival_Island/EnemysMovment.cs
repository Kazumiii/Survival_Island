using UnityEngine;
using System.Collections;

public class Przeciwnik_Poruszanie : MonoBehaviour
{
    //enemy's movments
    float distance;
    public Transform gracz;
    float time = 1.0f;


    //enemy's shooting
    float prędkość_strzału = 10.0f;
    public Transform lufka;
    public Transform lufka2;
    public GameObject pocisk;
    public GameObject pocisk2;
    float cdn;// shooting time



    // Update is called once per frame
    void Update()
    {

        cdn += Time.deltaTime;

        distance = Vector3.Distance(transform.position, gracz.position);
        Debug.Log(distance);
        if (distance < 10)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - gracz.position), time * Time.deltaTime);

            if (distance >= 5)
            {
                transform.position -= transform.forward * time * Time.deltaTime;
            }

            if (distance < 10)
            {
                if (cdn > 2)
                {
                    GameObject p = Instantiate(pocisk, lufka.position, lufka.rotation) as GameObject;
                    GameObject p2 = Instantiate(pocisk2, lufka2.position, lufka2.rotation) as GameObject;
                    p.rigidbody.velocity = -transform.forward * 500 * Time.deltaTime;
                    p2.rigidbody.velocity = -transform.forward * 500 * Time.deltaTime;
                    cdn = 0;
                    Destroy(p, 2);
                    Destroy(p2, 2);


                }
            }

        }
    }





}
