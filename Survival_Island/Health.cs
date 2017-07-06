using UnityEngine;
using System.Collections;

public class Zdrowie : MonoBehaviour
{


    //Health field
    public int ObecneHP;
    public const int MaxHP = 100;

    //Health color	
    public GUIStyle styleHP;

    // Use this for initialization
    void Start()
    {


        ObecneHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObecneHP > MaxHP)
            MaxHP = ObecneHP;

        if (ObecneHP < 0)
            ObecneHP = 0;
    }


    void OnGUI()
    {
        if (gameObject.name == "Gracz")
            GUI.Box(new Rect(0, 390, (Screen.width / 3) * ObecneHP / MaxHP, 30), ObecneHP + "/" + MaxHP, styleHP);
        else
        {
            GUI.Box(new Rect(Screen.width / 3, 0, (Screen.width / 3) * ObecneHP / MaxHP, 30), "Przeciwnik" + ObecneHP + "/" + MaxHP, styleHP);
        }
    }



    void Leczenie_Spoty(int hp)
    {
        ObecneHP += hp;
    }
    void Obrazenia(int hp)
    {
        ObecneHP -= hp;
    }


    void Leczenie_Mikstura(int hp)
    {
        ObecneHP += hp;
    }
}
