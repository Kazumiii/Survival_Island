using UnityEngine;
using System.Collections;

public class Gracz : MonoBehaviour
{
    //Sun
    public Light sun;
    bool open = false;

    //flashlight
    public Light latarka;
    public AudioClip DzwiekWłączeniaLatarki;
    public AudioClip DzwiekWyłąćzeniaLatarki;
    bool wlaczone = false;

    //Shooting
    public Transform LewyStrzał;
    public Transform PrawyStrzał;
    public GameObject pocisk;
    public static bool CzyStrzelac = true;

    //Teleportation

    public Transform[] Teleporty;
    // Use this for initialization

    //Experience


    //Cursor
    public Texture2D kursor;

    //Lives
    public GUITexture tekstura;
    public Texture2D[] zycia;
    public static int zycie = 3;

*/
	 

	 

	void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        //Check lives
        if (zycie == 3)
        {
            tekstura.texture = zycia[2];
        }
        else if (zycie == 2)
        {
            tekstura.texture = zycia[1];
        }
        else if (zycie == 1)
        {
            tekstura.texture = zycia[0];
        }

        //increase speed
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 6;
        }
        //increase jump
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q))
        {
            gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 50;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<CharacterMotor>().jumping.baseHeight = 2;

        }
        if (Input.GetKey(KeyCode.R))
        {
            gameObject.GetComponent<CharacterMotor>().jumping.baseHeight = 20;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Screen.lockCursor = true;
        }
        if (Input.GetButtonDown("Fire2"))
        {

            Screen.lockCursor = false;
        }

        //on-off sun
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (!open)
            {
                sun.enabled = false;
                open = true;
            }
            else
            {
                sun.enabled = true;
                open = false;
            }
        }

        //in-offf flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!wlaczone)
            {
                latarka.enabled = true;
                audio.PlayOneShot(DzwiekWłączeniaLatarki);
                wlaczone = true;
            }
            else
            {

                latarka.enabled = false;
                wlaczone = false;
                audio.PlayOneShot(DzwiekWyłąćzeniaLatarki);

            }
        }

        //shooting missailes
        #region Strzelanie(LPM,LPM-Control)
        if (Input.GetMouseButtonDown(0) && CzyStrzelac)
        {
            GameObject Pocisk = Instantiate(pocisk, LewyStrzał.position, LewyStrzał.rotation) as GameObject;
            Pocisk.rigidbody.velocity = transform.forward * 1000 * Time.deltaTime;

            Destroy(Pocisk, 5);
        }
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1) && CzyStrzelac)
        {

            GameObject Pocisk2 = Instantiate(pocisk, PrawyStrzał.position, PrawyStrzał.rotation) as GameObject;


            Pocisk2.rigidbody.velocity = transform.forward * 1000 * Time.deltaTime;

            Destroy(Pocisk2, 5);
        }
        #endregion

        //teleportation-old code
        #region Teleportacja(B,N)
        /*	if(Input.GetKeyDown(KeyCode.Z))
            {
                gameObject.transform.position=Teleporty[0].position;
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                gameObject.transform.position=Teleporty[1].position;
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                gameObject.transform.position=Teleporty[2].position;
            }*/
        #endregion



        //om=off menu during the game
        if (Input.GetKeyDown(KeyCode.Escape) && Menu.WyswietlMenu == false)
        {
            Menu.WyswietlMenu = true;
            CzyStrzelac = false;
            gameObject.GetComponent<MouseLook>().sensitivityX = 0;
            gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 0;
            Time.timeScale = 0;


        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu.WyswietlMenu == true)
        {
            Menu.WyswietlMenu = false;
            CzyStrzelac = true;
            gameObject.GetComponent<MouseLook>().sensitivityX = 10;
            gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 10;
            Time.timeScale = 1;
        }





    }




}
