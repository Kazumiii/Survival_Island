using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    //goup settings
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
    public static string Wycicz_Tekst = "Wycisz";
    public static string WlaczMuzyke_tekst = "Włącz muzyke";


    //Graphics
    public static int ObecnaWybranaJakoscGrafiki;
    public static int ObecnaWybranaRozdzielczosc;
    public static int OstatnioWybranaJakoscGrafiki;
    public static int OStatnioWybranaRozdzielczosc;
    public static bool Pelnyekran = false;
    public static string[] ListaJakosciGrafiki = new string[]
    {
        "Najszybsza","Szybka","Prosta","Dobra","Piękna","Przepiekna",
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
        if (Obecnepolozenie == "Menu główne")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 270), "");
            if (GUI.Button(new Rect(10, 10, 200, 30), "Nowa Gra"))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(10, 45, 200, 30), "Ustawienia"))
            {

                Obecnepolozenie = "Ustawienia";

            }
            if (GUI.Button(new Rect(10, 80, 200, 30), "Wyjście"))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(10, 135, 200, 100), "", style))
            {
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
            if (GUI.Button(new Rect(0, 270, 220, 30), "Powrót"))
            {
                Obecnepolozenie = "Menu główne";
            }
            GUI.EndGroup();
        }



        //Settings
        if (Obecnepolozenie == "Ustawienia")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 150), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Ustawienia gry");
            if (GUI.Button(new Rect(10, 35, 200, 30), "Grafika"))
            {
                Obecnepolozenie = "Grafika";
            }
            if (GUI.Button(new Rect(10, 70, 200, 30), "Dźwięk"))
            {
                Obecnepolozenie = "Dźwięk";
            }
            if (GUI.Button(new Rect(10, 105, 200, 30), "Powrót"))
            {

                if (Poziom == 0)
                    Obecnepolozenie = "Menu główne";
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
            GUI.Box(new Rect(0, 0, 220, 30), "Misja:" + NumerMisji);
            GUI.TextArea(new Rect(10, 35, 200, 100), OpisMisji);
            if (GUI.Button(new Rect(10, 140, 200, 30), "Powrót"))
            {

                Obecnepolozenie = "Scena1";
                WyswietlMenu = true;
            }
            GUI.EndGroup();
        }


        //Graphic settings

        if (Obecnepolozenie == "Grafika")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 170), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Grafika");
            if (GUI.Button(new Rect(10, 35, 200, 30), "Jakość grafikia"))
            {
                Obecnepolozenie = "Jakość grafiki";
            }
            if (GUI.Button(new Rect(10, 70, 200, 30), "Rozdzielczość"))
            {
                Obecnepolozenie = "Rozdzielczosc grafiki";
            }
            if (GUI.Button(new Rect(10, 115, 200, 30), "Powrót"))
            {


                Obecnepolozenie = "Ustawienia";

            }
            GUI.EndGroup();
        }



        //Sound settings

        if (Obecnepolozenie == "Dźwięk")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 190), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Dźwięk");

            gameObject.audio.volume = PoziomGłosności;
            PoziomGłosności = GUI.HorizontalScrollbar(new Rect(110, 40, 100, 30), PoziomGłosności, 0.1f, 0.0f, 1.1f);
            Wyciszenie = GUI.Toggle(new Rect(110, 80, 20, 20), Wyciszenie, "");
            if (WłączenieGlosnosci = GUI.Toggle(new Rect(110, 105, 20, 20), WłączenieGlosnosci, ""))
            {
                WlaczMuzyke_tekst = "Wyłącz muzke";
            }
            else
            {
                WlaczMuzyke_tekst = "Włącz muzyke";
            }


            GUI.Label(new Rect(10, 40, 100, 30), "Głośność" + " " + PoziomGłosności.ToString("F2"));
            GUI.Label(new Rect(10, 75, 100, 30), Wycicz_Tekst);
            GUI.Label(new Rect(10, 110, 100, 30), WlaczMuzyke_tekst);

            if (GUI.Button(new Rect(10, 140, 200, 30), "Powrót"))
            {

                Obecnepolozenie = "Ustawienia";
            }
        }
        GUI.EndGroup();





        //Graphic quality
        if (Obecnepolozenie == "Jakość grafiki")
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 190), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Jakość grafiki");

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


            if (GUI.Button(new Rect(10, 150, 200, 30), "Powrót"))
            {

                Obecnepolozenie = "Grafika";
            }
            GUI.EndGroup();

        }


        //Graphic resolution
        if (Obecnepolozenie == "Rozdzielczosc grafiki")
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 250), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Rozdzielczość grafiki");

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
        if (Obecnepolozenie == "Wczytaj gre")
        {
            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 250), "");
            GUI.Box(new Rect(0, 0, 220, 30), "Wczytaj gre");


            if (GUI.Button(new Rect(10, 160, 200, 30), "Powrót"))
            {


                if (Poziom == 0)
                    Obecnepolozenie = "Menu główne";
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
            if (GUI.Button(new Rect(10, 10, 200, 30), "Powrot do gry"))
            {
                WyswietlMenu = false;
                Gracz.CzyStrzelac = true;
                gameObject.GetComponent<MouseLook>().sensitivityX = 10;
                gameObject.GetComponentInChildren<Camera>().GetComponent<MouseLook>().sensitivityY = 10;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(10, 45, 200, 30), "Zapisz grę"))
            {
                Zapisz_gre();
                WyswietlMenu = false;

            }
            if (GUI.Button(new Rect(10, 80, 200, 30), "Wczytaj grę"))
            {
                Wczytaj_gre();

            }
            if (GUI.Button(new Rect(10, 115, 200, 30), "Opis misji"))
            {
                Obecnepolozenie = "Opis misji";
                WyswietlMenu = false;

            }
            if (GUI.Button(new Rect(10, 150, 200, 30), "Ustawienia gry"))
            {

                Obecnepolozenie = "Ustawienia";
                WyswietlMenu = false;
            }

            if (GUI.Button(new Rect(10, 185, 200, 30), "Powrót do menu"))
            {
                Application.LoadLevel(0);
                WyswietlMenu = false;
            }
            GUI.EndGroup();
        }

        if (Obecnepolozenie == "Zapisz gre")
        {

            GUI.BeginGroup(PolozenieUstawien);
            GUI.Box(new Rect(0, 0, 220, 80), "Gra zostala zapisna");
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


