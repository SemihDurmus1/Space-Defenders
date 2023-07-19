using System;
using System.IO;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    private int loginCount;

    private void Start()
    {
        LoginOku();

        loginCount = Convert.ToInt16(LoginOku());

        LoginSorgula();
    }

    private void LoginSorgula()
    {
        print("LogCount: " + loginCount);
        if (loginCount > 3)
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
            Debug.Log("Veri yoktu, bu yüzden 0 yazýldý");
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
}