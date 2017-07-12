using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    //group settings
    public Rect PolozenieUstawien;
    public static bool WyswietlMenu = false;

    //check which area I am
    public int Poziom = 0;

    //Settings field
    public string Obecnepolozenie = "Menu główne";

    public GUIStyle style;
    public string NazwaGry = "Nazwa Gry";
    public string WersjaGry = "1.0";
    public string Opis = "Opis gry";



    //field for quests description
    private string OpisMisji = "Znajdź broń";
    private int NumerMisji = 1;

    //Sound
    public static float PoziomGłosności;
    public static bool Wyciszenie = false;
    public static bool WłączenieGlosnosci = false;
    public static string Wycicz_Tekst = "Mute";
    public static string WlaczMuzyke_tekst = "Shut down music";


    //Graphics
    public static int ObecnaWybranaJakoscGrafiki;
    public static int ObecnaWybranaRozdzielczosc;
    public static int OstatnioWybranaJakoscGrafiki;
    public static int OStatnioWybranaRozdzielczosc;
    public static bool Pelnyekran = false;
    public static string[] ListaJakosciGrafiki = new string[]
    {
        "Fastest","Fast","Simple","Good","Beautiful",
    };
    public static string[] ListaRozdzielczosc = new string[]
    {
        "1024x768","1366x768","1600x900","1920x1080",
    };

    //Save game
    float x, y, z;
    bool przelacznik = false;



    void OnGUI()
    {

        // MENU
        if (Obecnepolozenie == "Menu ")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 270), "");
            if (GUI.Button(new Rect(10, 10, 200, 30), "New Game
            {
            //Load new game
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(10, 45, 200, 30), "Settings
            {

                Obecnepolozenie = "Settings

            }
            if (GUI.Button(new Rect(10, 80, 200, 30), "Exit
            {//Turn the game off
                Application.Quit();
            }

            if (GUI.Button(new Rect(10, 135, 200, 100), "", style))
            {
               //Load game's logo
               Obecnepolozenie = "Logo";
            }
            GUI.EndGroup();
        }


        //  LOGO
        if (Obecnepolozenie == "Logo")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 300), "");
            GUI.Box(new Rect(0, 0, 220, 30), NazwaGry);
            GUI.Box(new Rect(0, 35, 220, 30), "Wersja gry" + " " + WersjaGry);


            GUI.Label(new Rect(5, 90, 190, 140), Opis);
            if (GUI.Button(new Rect(0, 270, 220, 30), "Back
            {
                Obecnepolozenie = "Menu ";
            }
            GUI.EndGroup();
        }



        //Settings
        if (Obecnepolozenie == "Settings
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 150), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Settings");
            if (GUI.Button(new Rect(10, 35, 200, 30), "Graphic");
            {
                Obecnepolozenie = "Graphic";
            }
            if (GUI.Button(new Rect(10, 70, 200, 30), "Sound"));
            {
                Obecnepolozenie = "Sound";
            }
            if (GUI.Button(new Rect(10, 105, 200, 30), "Back"))
            {

                if (Poziom == 0)
                    Obecnepolozenie = "Menu ";
                else if (Poziom == 1)
                {
                    Obecnepolozenie = "Scena1";
                    WyswietlMenu = true;
                }
            }
            GUI.EndGroup();
        }






        //Quest description


        if (Obecnepolozenie == "Opis misji")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 300), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Quest"+NumerMisji);
            GUI.TextArea(new Rect(10, 35, 200, 100), OpisMisji);
            if (GUI.Button(new Rect(10, 140, 200, 30), "Back"))
            {

                Obecnepolozenie = "Scena1";
                WyswietlMenu = true;
            }
            GUI.EndGroup();
        }


        //Graphic settings

        if (Obecnepolozenie == "Graphic)
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 170), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Graphic);
            if (GUI.Button(new Rect(10, 35, 200, 30), "Graphic quality"))
            {
                Obecnepolozenie = "Graphc quality";
            }
            if (GUI.Button(new Rect(10, 70, 200, 30), "Resolution"))
            {
                Obecnepolozenie = "Graphic resolution";
            }
            if (GUI.Button(new Rect(10, 115, 200, 30), "Back")
            {


                Obecnepolozenie = "Settings";

            }
            GUI.EndGroup();
        }



        //Sound settings

        if (Obecnepolozenie == "Sound")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 190), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Sound");

            gameObject.audio.volume = PoziomGłosności;
            PoziomGłosności = GUI.HorizontalScrollbar(new Rect(110, 40, 100, 30), PoziomGłosności, 0.1f, 0.0f, 1.1f);
            Wyciszenie = GUI.Toggle(new Rect(110, 80, 20, 20), Wyciszenie, "");
            if (WłączenieGlosnosci = GUI.Toggle(new Rect(110, 105, 20, 20), WłączenieGlosnosci, ""))
            {
                WlaczMuzyke_tekst = "Shout music down";
            }
            else
            {
                WlaczMuzyke_tekst = "Turn music on";
            }


            GUI.Label(new Rect(10, 40, 100, 30), "Loudility"+" " + PoziomGłosności.ToString("F2"));
            GUI.Label(new Rect(10, 75, 100, 30), Wycicz_Tekst);
            GUI.Label(new Rect(10, 110, 100, 30), WlaczMuzyke_tekst);

            if (GUI.Button(new Rect(10, 140, 200, 30), "Back")
            {

                Obecnepolozenie = "Settings";
            }
        }
        GUI.EndGroup();





        //Graphic quality
        if (Obecnepolozenie == "Graphic quality"
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 190), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Graphic quality");

            ObecnaWybranaJakoscGrafiki = GUI.SelectionGrid(new Rect(10, 44, 200, 100), ObecnaWybranaJakoscGrafiki, ListaJakosciGrafiki, 2);

            if (OstatnioWybranaJakoscGrafiki != ObecnaWybranaJakoscGrafiki)
            {

                OstatnioWybranaJakoscGrafiki = ObecnaWybranaJakoscGrafiki;

                switch (ObecnaWybranaJakoscGrafiki)
                {
                    case 0: QualitySettings.SetQualityLevel(0); break;

                    case 1: QualitySettings.SetQualityLevel(1); break;

                    case 2: QualitySettings.SetQualityLevel(2); break;

                    case 3: QualitySettings.SetQualityLevel(3); break;

                    case 4: QualitySettings.SetQualityLevel(4); break;

                    case 5: QualitySettings.SetQualityLevel(5); break;

                }
            }


            if (GUI.Button(new Rect(10, 150, 200, 30), "Back")
            {

                Obecnepolozenie = "Graphic";
            }
            GUI.EndGroup();

        }


        //Graphic resolution
        if (Obecnepolozenie == "Graphic resolution")
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 250), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Graphic resolution");

            ObecnaWybranaRozdzielczosc = GUI.SelectionGrid(new Rect(10, 44, 200, 100), ObecnaWybranaRozdzielczosc, ListaRozdzielczosc, 2);

            if (OStatnioWybranaRozdzielczosc != ObecnaWybranaRozdzielczosc)
            {
                OStatnioWybranaRozdzielczosc = ObecnaWybranaRozdzielczosc;


                switch (ObecnaWybranaRozdzielczosc)
                {
                    case 0:
                        {
                            if (Pelnyekran)
                            {
                                Screen.SetResolution(1024, 768, true);
                            }

                            else
                            {
                                Screen.SetResolution(1024, 768, false);
                            }
                            break;
                        }

                    case 1:
                        {
                            if (Pelnyekran)
                            {
                                Screen.SetResolution(1366, 768, true);
                            }

                            else
                            {
                                Screen.SetResolution(1024, 768, false);
                            }
                            break;
                        }

                    case 2:
                        {

                            if (Pelnyekran)
                            {
                                Screen.SetResolution(1600, 900, true);
                            }

                            else
                            {
                                Screen.SetResolution(1600, 900, false);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (Pelnyekran)
                            {
                                Screen.SetResolution(1920, 1080, true);
                            }

                            else
                            {
                                Screen.SetResolution(1920, 1080, false);
                            }
                            break;
                        }

                }
            }
            if (GUI.Button(new Rect(10, 170, 200, 30), "Powrót"))
            {

                Obecnepolozenie = "Grafika";
            }
            Pelnyekran = GUI.Toggle(new Rect(110, 145, 20, 20), Pelnyekran, "");
            GUI.Label(new Rect(10, 145, 90, 90), "Pełny ekran");

            GUI.EndGroup();

        }








        //Load game
        if (Obecnepolozenie == "Load game")
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 250), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Load game");


            if (GUI.Button(new Rect(10, 160, 200, 30), "Back"))
            {


                if (Poziom == 0)
                    Obecnepolozenie = "Menu ";
                else if (Poziom == 1)
                {
                    Obecnepolozenie = "Scena1";
                    WyswietlMenu = true;
                }

                GUI.EndGroup();
            }
        }
        //display menu


        if (WyswietlMenu)
        {
            Obecnepolozenie = "Scena1";
            Poziom = 1;
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 440), "");
            if (GUI.Button(new Rect(10, 10, 200, 30), "Back to game"))
            {
                WyswietlMenu = false;
                Gracz.CzyStrzelac = true;
                gameObject.GetComponent<MouseLook>().sensitivityX = 10;
                gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 10;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(10, 45, 200, 30), "Save"))
            {
                Zapisz_gre();
                WyswietlMenu = false;

            }
            if (GUI.Button(new Rect(10, 80, 200, 30), "Load game"))
            {
                Wczytaj_gre();

            }
            if (GUI.Button(new Rect(10, 115, 200, 30), "Quest description"))
            {
                Obecnepolozenie = "Quest description";
                WyswietlMenu = false;

            }
            if (GUI.Button(new Rect(10, 150, 200, 30), "Settings"))
            {

                Obecnepolozenie ="Settings"
                WyswietlMenu = false;
            }

            if (GUI.Button(new Rect(10, 185, 200, 30), "Back to game"))
            {
                Application.LoadLevel(0);
                WyswietlMenu = false;
            }
            GUI.EndGroup();
        }

        if (Obecnepolozenie == "Save")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 80), "Game have save"))
            if (GUI.Button(new Rect(45, 35, 100, 30), "OK"))
            {

                Obecnepolozenie = "Scena1";
                Gracz.CzyStrzelac = true;
                gameObject.GetComponent<MouseLook>().sensitivityX = 10;
                gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 10;
                Time.timeScale = 1;
            }
            GUI.EndGroup();

        }

    }



    //save game
    void Zapisz_gre()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        PlayerPrefs.SetFloat("Polozenie X:", x);
        PlayerPrefs.SetFloat("Polozenie Y:", y);
        PlayerPrefs.SetFloat("Polozenie Z:", z);

        Obecnepolozenie = "Zapisz gre";



    }


    //Load game
    void Wczytaj_gre()
    {
        x = PlayerPrefs.GetFloat("Polozenie X:");
        y = PlayerPrefs.GetFloat("Polozenie Y:");
        z = PlayerPrefs.GetFloat("Polozenie Z:");

        transform.position = new Vector3(x, y, z);
        WyswietlMenu = false;
        Gracz.CzyStrzelac = true;
        gameObject.GetComponent<MouseLook>().sensitivityX = 10;
        gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 10;
        Time.timeScale = 1;
    }


}


