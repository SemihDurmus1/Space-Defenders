using System;
using System.IO;
using UnityEngine;

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
        Debug.Log("Current Date: " + currentDate);
        Debug.Log("Last Login Date: " + loginDate);


        LoginSorgula();


        if (loginDate != currentDate)
        {
            Debug.Log("Login Count Sýfýrlandý.");
            LoginYaz(1);
            DateYaz();
        }
    }

    private void LoginSorgula()
    {
        print("LogCount: " + loginCount);
        if (loginCount >= 3 && loginDate == currentDate)
        {
            Debug.Log("Oyuna giremezsin");
            Application.Quit();
        }
        loginCount++;
        LoginYaz(loginCount);
    }

    private static void LoginYaz(int count)
    {
        StreamWriter sw = new StreamWriter("loginCount.txt");
        sw.Write(count);
        sw.Close();
    }

    private string LoginOku()
    {
        DosyaYoksaOlustur();

        StreamReader sr = new StreamReader("loginCount.txt");
        string veri = sr.ReadLine();
        sr.Close();
        if (veri != null) { return veri; }
        else
        {
            LoginYaz(1);
            return "0";
        }
    }

    private static void DosyaYoksaOlustur()
    {
        if (!File.Exists("loginCount.txt"))
        {
            FileStream fs = File.Create("loginCount.txt");
            fs.Close();
        }
    }


    private static void DosyaYoksaOlusturDate()
    {
        if (!File.Exists("loginDate.txt"))
        {
            FileStream fs = File.Create("loginDate.txt");
            fs.Close();
        }
    }

    private string DateOku()
    {
        DosyaYoksaOlusturDate();

        StreamReader srDate = new StreamReader("loginDate.txt");
        string veriDate = srDate.ReadLine();
        srDate.Close();
        if (veriDate != null) { return veriDate; }
        else
        {
            DateYaz();
            Debug.Log("Dosya boþ olduðundan bugünün Datei Yazýldý: " + DateTime.Today.Day);
            return "0";
        }
    }

    private static void DateYaz()
    {
        StreamWriter swDate = new StreamWriter("loginDate.txt");
        swDate.Write(DateTime.Today.Day);
        swDate.Close();
    }
}