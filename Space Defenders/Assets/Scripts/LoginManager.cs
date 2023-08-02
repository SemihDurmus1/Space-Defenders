using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private int loginCount;
    private int loginDate;
    private int currentDate;

    private void Start()
    {
        currentDate = Convert.ToInt16(DateTime.Today.Day);

        LoginOku();
        loginCount = Convert.ToInt16(LoginOku());

        //DateOku();
        loginDate = Convert.ToInt16(DateOku());


        LoginSorgula();


        if (loginDate != currentDate)
        {
            LoginYaz(1);
            DateYaz();
        }
    }

    private void LoginSorgula()
    {
        if (loginCount >= 3 && loginDate == currentDate)
        {
            //Application.Quit();
            SceneManager.LoadScene(1);
        }
        loginCount++;
        LoginYaz(loginCount);
    }

    private static void LoginYaz(int count)
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/loginCount.txt");
        sw.Write(count);
        sw.Close();
    }

    private string LoginOku()
    {
        DosyaYoksaOlustur();

        StreamReader sr = new StreamReader(Application.persistentDataPath + "/loginCount.txt");
        string veri = sr.ReadLine();
        sr.Close();
        if (veri != null) { return veri; }
        else
        {
            LoginYaz(1);
            return "1";
        }
    }

    private static void DosyaYoksaOlustur()
    {
        if (!File.Exists(Application.persistentDataPath + "/loginCount.txt"))
        {
            FileStream fs = File.Create(Application.persistentDataPath + "/loginCount.txt");
            fs.Close();
        }
    }


    private static void DosyaYoksaOlusturDate()
    {
        if (!File.Exists(Application.persistentDataPath + "/loginDate.txt"))
        {
            FileStream fs = File.Create(Application.persistentDataPath + "/loginDate.txt");
            fs.Close();
        }
    }

    private string DateOku()
    {
        DosyaYoksaOlusturDate();

        StreamReader srDate = new StreamReader(Application.persistentDataPath + "/loginDate.txt");
        string veriDate = srDate.ReadLine();
        srDate.Close();
        if (veriDate != null) { return veriDate; }
        else
        {
            DateYaz();
            return "0";
        }
    }

    private static void DateYaz()
    {
        StreamWriter swDate = new StreamWriter(Application.persistentDataPath + "/loginDate.txt");
        swDate.Write(DateTime.Today.Day);
        swDate.Close();
    }
}